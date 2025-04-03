using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.repository.Interfaces
{
    public interface IBaseRepository<TEntity, TType> where TEntity : class
    {
        Task<OperationResult<List<TEntity>>> GetAll();
        Task<OperationResult<TEntity>> GetById(TType id);
        Task<OperationResult<TEntity>> Save(TEntity entity);
        Task<OperationResult<TEntity>> Update(TEntity entity);
        Task<bool> Exist(Expression<Func<TEntity, bool>> filter);
    }
}
