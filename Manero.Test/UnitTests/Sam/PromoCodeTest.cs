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

namespace Manero.Test.PromoCodeUnitTest
{
    public class PromoCodeTest
    {
        public class PromoCodeService_Test
        {
            [Fact]
            public async Task CreateAsync__Should_Create_New_PromoCode_And_Return_PromoCode()
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

            [Fact]
            public async Task GetAllAsync__Should_Return_List_Of_PromoCodes()
            {
                // Arrange
                var mockRepo = new Mock<IPromoCodeRepo>();
                var promoCodeService = new PromoCodeService(mockRepo.Object);
                var promoCodes = new List<PromoCodeEntity>
            {
                new PromoCodeEntity { Id = Guid.NewGuid(), Name = "Promo 1", Discount = 10, ExpiryDate = DateTime.UtcNow.AddDays(7) },
                new PromoCodeEntity { Id = Guid.NewGuid(), Name = "Promo 2", Discount = 20, ExpiryDate = DateTime.UtcNow.AddDays(14) },
                new PromoCodeEntity { Id = Guid.NewGuid(), Name = "Promo 3", Discount = 30, ExpiryDate = DateTime.UtcNow.AddDays(21) }
            };
                mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(promoCodes);

                // Act
                var result = await promoCodeService.GetAllAsync();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(promoCodes.Count, result.Count());
                Assert.Equal(promoCodes, result);
            }
        }
    }
}
