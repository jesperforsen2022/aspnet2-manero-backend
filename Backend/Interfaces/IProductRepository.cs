using Backend.Models.Entities;

namespace Backend.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity> AddAsync(ProductEntity entity);
        Task<List<ProductEntity>> GetAsync();
        Task<ProductEntity> GetById(Guid id);
        Task<List<ProductEntity>> GetByTag(string tag, int take);
    }
}