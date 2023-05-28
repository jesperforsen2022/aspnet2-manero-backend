using System.Linq.Expressions;

namespace Backend.Interfaces
{
    public interface IGeneralRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsyncWhere(Expression<Func<TEntity, bool>> predicate);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> RemoveRangeAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}