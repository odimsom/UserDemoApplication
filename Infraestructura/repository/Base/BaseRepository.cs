using Domain;
using Infraestructura.repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructura.repository.Base
{
    public class BaseRepository<TEntity, TType> : IBaseRepository<TEntity, TType> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private Microsoft.EntityFrameworkCore.DbSet<TEntity> Entity { get; set; }
        private OperationResult<TEntity> result;

        public BaseRepository(ApplicationContext context, OperationResult<TEntity> result)
        {
            _context = context;
            Entity = _context.Set<TEntity>();
            this.result = result;
        }

        public virtual async Task<OperationResult<List<TEntity>>> GetAll()
        {
            OperationResult<List<TEntity>> result = new();
            try
            {
                result.Data = await Entity.ToListAsync();
                result.Message = "entidad octenida correctamente";
            }
            catch(Exception ex)
            {
                result.Message = "error octeniendo la entidad" + ex;
                result.Succes = false;
            }
            return result;
        }

        public virtual async Task<OperationResult<TEntity>> GetById(TType id)
        {
            try
            {
                result.Data = await Entity.FindAsync(id);
                result.Message = "Entidad octenida correctamente";
            }catch(Exception ex)
            {
                result.Message = "Error octeniendo la entidad" + ex;
                result.Succes = false;
            }
            return result;
        }

        public virtual async Task<OperationResult<TEntity>> Save(TEntity entity)
        {
            try
            {
                result.Data = entity;
                Entity.Add(entity);
                await _context.SaveChangesAsync();
                result.Message = "Entitda Guardada Correctamente";
            }catch(Exception ex)
            {
                result.Message = "Error Octeniendo la entidad" + ex;
                result.Succes = false;
            }
            return result;
        }

        public virtual async Task<OperationResult<TEntity>> Update(TEntity entity)
        {
            try
            {
                Entity.Update(entity);
                await _context.SaveChangesAsync();
                result.Data = entity;
                result.Message = "Entiti Actualizada Correctamente";
            }catch(Exception ex)
            {
                result.Message = "Error Actualizando la entidad" + ex;
                result.Succes = false;
            }
            return result;
        }

        public virtual async Task<bool> Exist(Expression<Func<TEntity, bool>> filter)
        {
            return await Entity.AnyAsync(filter);
        }
    }
}
