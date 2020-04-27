using Library.Api.Util;
using Library.Domain.DTO;
using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Library.Api.Controllers
{
    public class UserController : Controller
    {
        private IUserService _usuarioService;

        private IConfiguration _configuration;

        /// <param name="configuration">Configuração do Projeto</param>
        /// <param name="usuarioService">Usuario Service</param>

        public UserController(IConfiguration configuration, IUserService usuarioService)
            : base()
        {
            _configuration = configuration;
            _usuarioService = usuarioService;

        }

        [Route("GetUserById")]
        [HttpGet]
        public ActionResult GetUserById(int id)
        {
            try
            {
                var user = _usuarioService.GetUserById(id);

                return Ok(new { User = user });
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Mensagem: {ex.Message} ");
            }
        }

        [HttpPost("[action]")]
        public ActionResult InsertUser([FromBody] User model)
        {
            try
            {
                if (model != null)
                {
                    model.Password = GenericHash.GerarHash(model.Password);
                    _usuarioService.Add(model);
                }
                else
                {
                    return Ok(new { Mesagem = false });
                }

                return Ok(new { Mesagem = true });
            }
            catch (System.Exception ex)
            {

                return BadRequest($"Mensagem: {ex.Message} ");
            }
        }
    }
}
