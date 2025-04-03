using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Aplication;
using Web.Domain;

namespace Web.Entrada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AutenticacionService _autenticacionService;

        public AuthController(AutenticacionService autenticacionService)
        {
            _autenticacionService = autenticacionService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] Usuario usuario)
        {
            var user = await _autenticacionService.IniciarSesion(usuario.Correo, usuario.Contrasenia);
            if (user == null)
                return Unauthorized("Credenciales inválidas");
            return Ok(user);
        }
    }
}
