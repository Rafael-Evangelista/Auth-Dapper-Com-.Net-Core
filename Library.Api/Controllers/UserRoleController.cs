using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Library.Api.Controllers
{
    public class UserRoleController : Controller
    {
        private IUserRoleService _userRoleService;

        private IConfiguration _configuration;

        /// <param name="configuration">Configuração do Projeto</param>
        /// <param name="userRoleService">Role do Usuario Service</param>

        public UserRoleController(IConfiguration configuration, IUserRoleService userRoleService)
            : base()
        {
            _configuration = configuration;
            _userRoleService = userRoleService;
        }

        [Route("GetUserRoles")]
        [HttpGet]
        public ActionResult GetUserRoles()
        {
            try
            {
                var roles = _userRoleService.GetAll();

                return Ok(new { UserRoles = roles });
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Mensagem: {ex.Message} ");
            }
        }
    }
}
