using Domain;
using Infraestructura.repository.Base;
using Infraestructura.repository.Interfaces;

namespace Infraestructura.repository
{
    public class UsuarioRepositoy : BaseRepository<Usuario, int>, IUsuarioRepositoy
    {
        private readonly ApplicationContext _contex;
        private readonly OperationResult<Usuario> _result;

        public UsuarioRepositoy(ApplicationContext contex, OperationResult<Usuario> result)
            : base(contex, result)
        {
            _contex = contex;
            _result = result;
        }

        public override async Task<OperationResult<List<Usuario>>> GetAll()
        {
            var result = new OperationResult<List<Usuario>>();
            try
            {
                result.Data = _contex.Usuarios.ToList();
                result.Message = "Datos obtenidos correctamente";
            }
            catch (Exception ex)
            {
                result.Succes = false;
                result.Message = $"Error: {ex.Message}";
            }
            return result;
        }

        public override async Task<OperationResult<Usuario>> Save(Usuario usuario)
        {
            OperationResult<Usuario> result = new();
            try
            {
                result.Data = usuario;
                result.Message = "Usuario agregado correctamente";
                await _contex.Usuarios.AddAsync(usuario);
                await _contex.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                result.Message = "Error Octeniendo La entidad";
                result.Succes = false;
            }

            return result;
        }

        public override async Task<OperationResult<Usuario>> Update(Usuario usuario)
        {
            OperationResult<Usuario> result = new();
            try
            {
                var entity = await GetById(usuario.Id);
                var update = entity.Data;
                update.Nombre = usuario.Nombre;
                update.Correo = usuario.Correo;
                update.Contrasenia = usuario.Contrasenia;
                _contex.Usuarios.Update(update);
                await _contex.SaveChangesAsync();
                result.Data = update;
                result.Message = "Entidad axtualizada correctamente";
            }catch(Exception ex)
            {
                result.Message = "Error Actualizando La Entidad: " + ex;
            }
            return result;
        }
    }
}
