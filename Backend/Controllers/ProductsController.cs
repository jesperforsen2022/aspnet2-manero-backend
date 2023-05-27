using Backend.Contexts;
using Backend.Models;
using Backend.Models.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductEntity product)
        {
            if (ModelState.IsValid)
            {
                ProductEntity productEntity = product;
                await _productService.CreateProduct(productEntity);
                return Ok(productEntity);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ProductEntity> products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ProductEntity product = await _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("{tag}/{take}")]
        public async Task<IActionResult> GetByTag(string tag, int take)
        {
            List<ProductEntity> products = await _productService.GetProductsByTag(tag, take);
            return Ok(products);
        }
    }
}
