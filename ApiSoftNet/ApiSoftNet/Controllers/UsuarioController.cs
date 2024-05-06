using ApiSoftNet.BusinessLogic;
using ApiSoftNet.BusinessLogic.Impl;
using ApiSoftNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSoftNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioBL _IUsuarioBL;
        
        public UsuarioController(IConfiguration configuration) 
        {
            _IUsuarioBL = new UsuarioBL(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Usuario> lst = null;
                lst = _IUsuarioBL.ListarUsuario();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            try
            {
                Usuario lst = null;
                lst = _IUsuarioBL.ListarUsuarioID(id);
                return Ok(lst);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Error" });
            }
        }

        [HttpPost]
        public IActionResult InsertarUsuario(Usuario usuario)
        {
            try
            {
                int id = _IUsuarioBL.InsertarUsuario(usuario);
                return Ok(id);
            }
            catch (Exception)
            {
                return new JsonResult(new { success = false, message = "Error" });
            }
        }

        [HttpPut]
        public IActionResult ActualizarUsuario(Usuario usuario)
        {
            try
            {
                int id = _IUsuarioBL.ActualizarUsuario(usuario);
                return Ok(id);
            }
            catch (Exception)
            {
                return new JsonResult(new { success = false, message = "Error" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            try
            {
                int ids = _IUsuarioBL.EliminarUsuario(id);
                return Ok(ids);
            }
            catch (Exception)
            {
                return new JsonResult(new { success = false, message = "Error" });
            }
        }

    }
}
