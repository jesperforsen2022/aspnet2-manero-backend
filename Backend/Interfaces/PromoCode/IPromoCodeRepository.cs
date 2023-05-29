﻿namespace Backend.Interfaces.PromoCode
{
    public interface IPromoCodeRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> DeleteAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}