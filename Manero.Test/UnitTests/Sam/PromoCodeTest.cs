using Backend.Controllers;
using Backend.Interfaces.PromoCode;
using Backend.Models.Entities;
using Backend.Models.Schemas;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Manero.Test.UnitTests.Sam
{
    public class PromoCodeTest
    {
        public class PromoCodeService_Test
        {
            [Fact]
            public async Task CreateAsync_Should_Create_New_PromoCode_And_Return_PromoCode()
            {
                // Arrange
                var promoCodeServiceMock = new Mock<IPromoCodeService>();
                var pCSchema = new PromoCodeSchema { Name = "New Promo", Discount = 0.15m, ExpiryDate = DateTime.Now.AddDays(10) };
                var createdPromoCode = new PromoCodeEntity { Id = Guid.NewGuid(), Name = "New Promo", Discount = 0.15m, ExpiryDate = DateTime.Now.AddDays(10) };
                promoCodeServiceMock.Setup(service => service.CreateAsync(pCSchema)).ReturnsAsync(createdPromoCode);

                var controller = new PromoCodeController(promoCodeServiceMock.Object);

                // Act
                var result = await controller.Create(pCSchema);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var model = Assert.IsType<PromoCodeEntity>(okResult.Value);
                Assert.Equal(createdPromoCode, model);
            }
        }
    }
}
