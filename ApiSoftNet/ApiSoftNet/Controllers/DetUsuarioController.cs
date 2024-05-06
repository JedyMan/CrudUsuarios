using ApiSoftNet.BusinessLogic;
using ApiSoftNet.BusinessLogic.Impl;
using ApiSoftNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSoftNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DetUsuarioController : ControllerBase
    {
        private readonly IDetUsuarioBL _IDetUsuarioBL;

        public DetUsuarioController(IConfiguration configuration)
        {
            _IDetUsuarioBL = new DetUsuarioBL(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<UsuarioDet> lst = null;
                lst = _IDetUsuarioBL.ListarDetalleUsuario();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertarDetalleUsuario(UsuarioDet usuario)
        {
            try
            {
                int id = _IDetUsuarioBL.InsertarDetalleUsuario(usuario);
                return Ok(id);
            }
            catch (Exception)
            {
                return new JsonResult(new { success = false, message = "Error" });
            }
        }
    }
}
