using Backend.Contexts;
using Backend.Interfaces.PromoCode;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories.PromoCode
{
    public abstract class PromoCodeRepository<TEntity> : IPromoCodeRepository<TEntity> where TEntity : class
    {
        private readonly NoSqlContext _nosql;

        protected PromoCodeRepository(NoSqlContext nosql)
        {
            _nosql = nosql;
        }


        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity != null)
            {
                _nosql.Set<TEntity>().Add(entity);
                await _nosql.SaveChangesAsync();
                return entity;
            }
            return null!;
        }


        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _nosql.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> DeleteAsync(Guid id)
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
    }
}
