using Backend.Contexts;
using Backend.Interfaces;
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
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest schema)
        {
            if (ModelState.IsValid)
            {
                ProductRequest productRequest = schema;
                await _productService.CreateAsync(productRequest);
                return Ok(productRequest);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            if (products != null)
                return Ok(products);

            return NotFound();
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
