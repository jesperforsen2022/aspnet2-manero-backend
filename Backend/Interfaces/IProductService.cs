using Backend.Models;
using Backend.Models.Entities;

namespace Backend.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreateAsync(ProductRequest schema);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<ProductEntity> GetProductById(Guid id);
        Task<List<ProductEntity>> GetProductsByTag(string tag, int take);
    }
}