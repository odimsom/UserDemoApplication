using Application;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apliction.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            OperationResult<List<Usuario>> result = new();
            try
            {
                result = await _service.Get();
            }
            catch(Exception ex)
            {
                result.Message = "error en la api" + ex;
            }
            return Ok(result);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            OperationResult<Usuario> result = new();
            try
            {
                result = await _service.GetById(id);
            }
            catch (Exception ex)
            {
                result.Message = "Error en la api: " + ex;
                result.Succes = false;
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            OperationResult<Usuario> result = new();
            try
            {
                result = await _service.SaveUsuario(usuario);
            }
            catch(Exception ex)
            {
                result.Message = "Erro en la api: " + ex;
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Usuario usuario)
        {
            OperationResult<Usuario> result = new();
            try
            {
                result = await _service.UpdateAsync(usuario);
            }
            catch (Exception ex)
            {
                result.Message = "Erro en la api: " + ex;
            }

            return Ok(result);
        }
    }
}
