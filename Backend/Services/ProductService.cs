using Backend.Contexts;
using Backend.Models;
using Backend.Models.Entities;
using Backend.Repositories;
using Backend.Repositories.Users;

namespace Backend.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo;

        public ProductService(ProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task CreateProduct(ProductEntity product)
        {
            await _productRepo.Create(product);
        }

        public async Task<ProductEntity> GetProductById(Guid id)
        {
            return await _productRepo.GetById(id);
        }

        public async Task<List<ProductEntity>> GetAllProducts()
        {
            return await _productRepo.GetAll();
        }

        public async Task<List<ProductEntity>> GetProductsByTag(string tag, int take)
        {
            return await _productRepo.GetByTag(tag, take);
        }

    }
}
