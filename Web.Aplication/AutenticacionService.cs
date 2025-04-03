using Web.Domain;

namespace Web.Aplication
{
    public class AutenticacionService
    {
        private readonly IUsuarioRepositorio _repositorio;

        public AutenticacionService(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Usuario> IniciarSesion(string correo, string contrasenia)
        {
            var usuarios = await _repositorio.ObtenerTodos();
            return usuarios?.FirstOrDefault(u => u.Correo == correo && u.Contrasenia == contrasenia);
        }
    }
}
