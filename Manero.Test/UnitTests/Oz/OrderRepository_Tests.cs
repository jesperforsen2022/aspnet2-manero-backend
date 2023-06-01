using Backend.Interfaces;
using Backend.Services;
using Backend.Models;
using Backend.Models.Entities;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Moq;
using Backend.Models.Dtos;
using System.Linq.Expressions;
using Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using Backend.Contexts;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;
using Backend.Models.Entities.User;
using Backend.Interfaces.PromoCode;

namespace Manero.Test.UnitTests.Oz
{
    public class OrderRepository_Tests
    {
        
        private Mock<IOrderRepository> _orderRepo;
        private IOrderService _orderService;

        public OrderRepository_Tests()
        {
            _orderRepo = new Mock<IOrderRepository>();
            _orderService = new OrderService(_orderRepo.Object);
        }

       
        [Fact]
        public async void CreateOrder_Should_Create_One_Order_end_return_It()
        {
            //Arrange
            OrderUserProfileModel _profile = new OrderUserProfileModel
            {
                Email = "TestEpost",
                Name = "TestNamn",
                RoleId = Guid.NewGuid(),
                PhoneNumber = "1234567890",
                ImageSrc = "TestImageSrc"
            };

            OrderUserProfileModel _profileModel = new OrderUserProfileModel
            {
                Email = "TestEpost",
                Name = "TestNamn",
                //RoleId = Guid.NewGuid(),
                PhoneNumber = "1234567890",
                ImageSrc = "TestImageSrc"
            };

            OrderAddressModel _address = new OrderAddressModel
            {
                Address = "TestAddress",
                PostalCode = "12345",
                City = "TestCity"
            };

            OrderModel orderModel = new OrderModel
            {
                Price = 101,
                Profile = _profileModel,
                Address = _address,
                PaymentMethod = "TestPaymentMethod",
                Comment = "TestComment",
                Delivery = "TestDelivery",
            };

            OrderEntity order = new OrderEntity
            {
                Id = Guid.NewGuid(),
                Price = 101,
                Date = DateTime.UtcNow,
                Profile = _profile,
                Address = _address,
                Products = new List<OrderProductModel>(),
                OrderStatus = "Order is placed",
                PaymentMethod = "TestPaymentMethod",
                Comment = "TestComment",
                Delivery = "TestDelivery",
                PromoCodes = new List<PromoCodeModel>()
            };

            var Status200OK = "200";
            var expected = "test";

            _orderRepo.Setup(x => x.CreateOrder(It.IsAny<OrderModel>())).ReturnsAsync(new OkObjectResult(order));

            // Act
            var result = await _orderService.CreateOrder(orderModel);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.NotNull(result);
        }    
    }
}