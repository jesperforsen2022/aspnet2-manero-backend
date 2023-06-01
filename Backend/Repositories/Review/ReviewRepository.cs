using Backend.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Backend.Repositories
{
    public abstract class ReviewRepository<TEntity> : IReviweRepository<TEntity> where TEntity : class
    {
        private readonly NoSqlContext _nosql;

        public ReviewRepository(NoSqlContext nosql)
        {
            _nosql = nosql;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    _nosql.Set<TEntity>().Add(entity);
                    await _nosql.SaveChangesAsync();
                    return entity;
                }
                return null!;
            }
            catch (Exception ex) 
            { Debug.WriteLine(ex.Message); }

            return null!;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await _nosql.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            { Debug.WriteLine(ex.Message); }

            return null!;
        }

        public virtual async Task<TEntity> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _nosql.Set<TEntity>().FindAsync(id);

                if (entity != null)
                {
                    _nosql.Set<TEntity>().Remove(entity);
                    await _nosql.SaveChangesAsync();
                    return entity;
                }
                return null!;
            }
            catch (Exception ex)
            { Debug.WriteLine(ex.Message); }

            return null!;
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            try
            {
                return await _nosql.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            { Debug.WriteLine(ex.Message); }

            return null!;
        }

    }
}
