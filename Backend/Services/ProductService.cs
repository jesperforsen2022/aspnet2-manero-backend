using Backend.Contexts;
using Backend.Interfaces;
using Backend.Models;
using Backend.Models.Entities;
using Backend.Repositories;
using Backend.Repositories.Users;
using System.Diagnostics;

namespace Backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<Product> CreateAsync(ProductRequest schema)
        {
            try
            {
                if (schema != null)
                    return await _productRepo.AddAsync(schema);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return null!;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                var items = new List<Product>();
                var products = await _productRepo.GetAsync();
                foreach (var entity in products)
                    items.Add(entity);

                if (items.Count > 0)
                    return items;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<ProductEntity> GetProductById(Guid id)
        {
            return await _productRepo.GetById(id);
        }

        public async Task<List<ProductEntity>> GetProductsByTag(string tag, int take)
        {
            return await _productRepo.GetByTag(tag, take);
        }

    }
}
