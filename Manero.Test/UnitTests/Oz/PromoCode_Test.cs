using Backend.Controllers;
using Backend.Interfaces.PromoCode;
using Backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manero.Test.UnitTests.Oz
{//
    public class PromoCode_Test
    {
        [Fact]
        public async Task Delete_ReturnsOkResultWithDeletedPromoCode()
        {
            // Arrange
            var promoCodeService_Mock = new Mock<IPromoCodeService>();
            var promoCodeId = Guid.NewGuid();
            var deletedPromoCode = new PromoCodeEntity { Id = promoCodeId, Name = "Promo", Discount = 0.1m, ExpiryDate = DateTime.Now.AddDays(7) };
            promoCodeService_Mock.Setup(x => x.DeleteAsync(promoCodeId)).ReturnsAsync(deletedPromoCode);

            var controller = new PromoCodeController(promoCodeService_Mock.Object);

            // Act
            var result = await controller.Delete(promoCodeId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<PromoCodeEntity>(okResult.Value);
            Assert.Equal(deletedPromoCode, model);
        }
    }
}
