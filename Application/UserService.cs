using Domain;
using Infraestructura.repository.Interfaces;
using System.Threading.Tasks;

namespace Application
{
    public class UserService
    {
        private readonly IUsuarioRepositoy _repository;
        private readonly OperationResult<Usuario> _result;

        public UserService(IUsuarioRepositoy repository, OperationResult<Usuario> result)
        {
            _repository = repository;
            _result = result;
        }

        public async Task<OperationResult<List<Usuario>>> Get()
        {
            OperationResult<List<Usuario>> result = new();
            try
            {
                result = await _repository.GetAll();
            }
            catch(Exception ex)
            {
                result.Message = "Error Octeniendo las entidades desde el servicio" + ex;
                result.Succes = false;
            }
            return result;
        }

        public async Task<OperationResult<Usuario>> GetById(int id)
        {
            OperationResult<Usuario> result = new();
            try
            {
                result = await _repository.GetById(id);
            }
            catch(Exception ex)
            {
                result.Message = "mal" + ex;
                result.Succes = false;
            }
            return result;
        }

        public async Task<OperationResult<Usuario>> SaveUsuario(Usuario usuario)
        {
            OperationResult<Usuario> result = new();
            try
            {
                result = await _repository.Save(usuario);
            }
            catch(Exception ex)
            {
                result.Message = "No se guardo pana: " + ex;
                result.Succes = false;
            }
            return result;
        }

        public async Task<OperationResult<Usuario>> UpdateAsync(Usuario usuario)
        {
            OperationResult<Usuario> result = new();
            try
            {
                result = await _repository.Update(usuario);
            }
            catch (Exception ex)
            {
                result.Message = "No se Actualizo pana: " + ex;
                result.Succes = false;
            }
            return result;
        }
    }
}
