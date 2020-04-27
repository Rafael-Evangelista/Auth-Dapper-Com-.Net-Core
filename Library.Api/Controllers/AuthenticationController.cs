using Library.Api.Util;
using Library.Domain.DTO;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private IUserService _usuarioService;

        private IRoleService _roleService;

        private IConfiguration _configuration;

        /// <param name="configuration">Configuração do Projeto</param>
        /// <param name="usuarioService">Usuario Service</param>

        public AuthenticationController(IConfiguration configuration, IUserService usuarioService, IRoleService roleService)
            : base()
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
            _roleService = roleService;

        }

        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(JwtSecurityTokenHandler))]
        [ProducesResponseType(400)]
        public IActionResult Login([FromBody] UserDTO userParam)
        {
            Role role = new Role();
            //userParam.Password = GenericHash.VerificarHash(userParam.Password);

            var user = _usuarioService.Login(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            foreach (var item in user)
            {
                role = _roleService.GetById(item.UserRole.RoleId);
            }

            var token = GenarateJwToken(userParam.Username, role.Name);

            return Ok(new { Token = token });

        }

        private async Task<string> GenarateJwToken(string userName, string userRole)
        {
            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, userRole)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
