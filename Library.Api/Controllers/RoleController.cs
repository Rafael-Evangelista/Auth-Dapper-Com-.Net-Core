using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Library.Api.Controllers
{
    public class RoleController : Controller
    {
        private IRoleService _roleService;

        private IConfiguration _configuration;

        /// <param name="configuration">Configuração do Projeto</param>
        /// <param name="roleService">Role Service</param>

        public RoleController(IConfiguration configuration, IRoleService roleService)
            : base()
        {
            _configuration = configuration;
            _roleService = roleService;

        }

        [Route("GetRoles")]
        [HttpGet]
        public ActionResult GetRoles()
        {
            try
            {
                var roles = _roleService.GetAll();

                return Ok(new { Mesagem = roles });
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Mensagem: {ex.Message} ");
            }
        }

        [HttpPost("[action]")]
        public ActionResult Insert([FromBody] Role model)
        {
            try
            {
                if (model != null)
                {
                    _roleService.Add(model);
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

        [HttpPut("[action]")]
        public ActionResult Update([FromBody] Role model)
        {
            try
            {
                if (model != null)
                {
                    _roleService.Update(model);
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

        [HttpDelete("[action]")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    _roleService.Remove(id);
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
