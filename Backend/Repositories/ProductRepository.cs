using Backend.Contexts;
using Backend.Models.Entities;
using Backend.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Interfaces;

namespace Backend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NoSqlContext _noSql;

        public ProductRepository(NoSqlContext noSql)
        {
            _noSql = noSql;
        }

        public async Task<ProductEntity> AddAsync(ProductEntity entity)
        {
            if (entity != null)
            {
                _noSql.ProductsCatalog.Add(entity);
                await _noSql.SaveChangesAsync();
                return entity;
            }

            return null!;
        }

        public async Task<List<ProductEntity>> GetAsync()
        {
            {
                var entities = await _noSql.ProductsCatalog.ToListAsync();
                if (entities.Any())
                    return entities;

                return null!;
            }
        }

        public async Task<ProductEntity> GetById(Guid id)
        {
            return await _noSql.ProductsCatalog.FindAsync(id);
        }


        public async Task<List<ProductEntity>> GetByTag(string tag, int take)
        {
            var products = await _noSql.ProductsCatalog.Take(take).ToListAsync();
            var filteredProducts = products.Where(x => x.Tags.Contains(tag)).ToList();
            return filteredProducts;
        }

    }
}
