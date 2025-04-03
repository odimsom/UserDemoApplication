using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Aplication;

namespace Web.Entrada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public DashboardController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetDashboard(int id)
        {
            var usuario = await _usuarioRepositorio.ObtenerPorId(id);
            if (usuario == null)
                return NotFound("Usuario no encontrado");

            return Ok(new
            {
                Usuario = usuario.Nombre,
                HoraActual = DateTime.Now.ToString("HH:mm:ss")
            });
        }
    }
}
