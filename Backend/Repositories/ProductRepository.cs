using Backend.Contexts;
using Backend.Models.Entities;
using Backend.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Repositories
{
    public class ProductRepository
    {
        private readonly NoSqlContext _noSql;

        public ProductRepository(NoSqlContext noSql)
        {
            _noSql = noSql;
        }

        public async Task<ProductEntity> GetById(Guid id)
        {
            return await _noSql.ProductsCatalog.FindAsync(id);
        }

        public async Task<List<ProductEntity>> GetAll()
        {
            return await _noSql.ProductsCatalog.ToListAsync();
        }

        public async Task<List<ProductEntity>> GetByTag(string tag, int take)
        {
            var products = await _noSql.ProductsCatalog.Take(take).ToListAsync();
            var filteredProducts = products.Where(x => x.Tags.Contains(tag)).ToList();
            return filteredProducts;
        }

        public async Task Create(ProductEntity product)
        {
            _noSql.ProductsCatalog.Add(product);
            await _noSql.SaveChangesAsync();
        }
    }
}
