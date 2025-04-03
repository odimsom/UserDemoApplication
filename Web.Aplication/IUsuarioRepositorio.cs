using Web.Domain;

namespace Web.Aplication
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> ObtenerPorId(int id);
        Task<IEnumerable<Usuario>> ObtenerTodos();
        Task<Usuario> Crear(Usuario usuario);
    }
}
