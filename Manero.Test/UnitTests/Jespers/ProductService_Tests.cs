using Backend.Controllers;
using Backend.Interfaces;
using Backend.Models;
using Backend.Models.Entities;
using Backend.Models.Entities.User;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Manero.Test.UnitTests.Jespers
{
    public class ProductService_Tests
    {
        private Mock<IProductRepository> _productRepo;
        private IProductService _productService;

        public ProductService_Tests()
        {
            _productRepo = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepo.Object);
        }

        [Fact]

        public async Task Get_Products__Should_Create_Product()
        {
            //Arrange
            ProductRequest schema = new ProductRequest
            {
                Name = "Sko",
                Price = 2,
                Category = "Skor",
                Description = "Snygga skor",
                ImageName = "string"
            };

            ProductEntity entity = new ProductEntity
            {
                Id = Guid.NewGuid(),
                Name = "Sko",
                Price = 2,
                Category = "Skor",
                Description = "Snygga Skor",
                ImageName = "String",
                Color = "string",
                Gender = "string",

            };

            _productRepo.Setup(x => x.AddAsync(It.IsAny<ProductEntity>())).ReturnsAsync(entity);


            //Act
            var result = await _productService.CreateAsync(schema);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
        }

    }
}
