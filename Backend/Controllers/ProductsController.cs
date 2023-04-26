using Backend.Contexts;
using Backend.Models;
using Backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NoSqlContext _nosql;

        public ProductsController(NoSqlContext nosql)
        {
            _nosql = nosql;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest product)
        {
            ProductEntity productEntity = product;
            _nosql.ProductsCatalog.Add(productEntity);
            await _nosql.SaveChangesAsync();

            Product _product = productEntity;

            return Ok(_product);
        }

        [HttpGet]

        public async Task <IActionResult> GetAll()
        {
            var products = await _nosql.ProductsCatalog.ToListAsync();
            return Ok(products);
        }
    }
}
