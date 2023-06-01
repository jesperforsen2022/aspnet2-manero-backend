using Backend.Interfaces;
using Backend.Services;
using Backend.Models;
using Backend.Models.Entities;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Moq;
using Backend.Models.Dtos;

namespace Manero.Test.UnitTests
{
    public class OrderRepository_Tests
    {
        private Mock<IOrderRepository> _orderRepo;
        //private Mock<IOrderModel> _orderModel;
        private IOrderService _orderService;

        public OrderRepository_Tests() 
        {
            _orderRepo = new Mock<IOrderRepository>();
            //_orderModel = new Mock<IOrderModel>();
            _orderService = new OrderService(_orderRepo.Object);
            //_orderService = new OrderService(_orderModel.Object);
        }


        [Fact]
        public async void CreateOrder__Should_Create_New_OrderEntity_And_Return_Order()
        {
            // Arrange
            OrderModel orderModel = new OrderModel {
                Price = 101,
                Profile = {
                    Email = "TestEpost",
                    Name = "TestNamn",
                    RoleId = Guid.NewGuid(),
                    PhoneNumber = "1234567890",
                    ImageSrc = "TestImageSrc"
                },
                Address = {
                    Address = "TestAddress",
                    PostalCode = "12345",
                    City = "TestCity"
                },
                PaymentMethod = "TestPaymentMethod",
                Comment = "TestComment",
                Delivery = "TestDelivery",
            };
            OrderEntity order = new OrderEntity{
                Id = Guid.NewGuid(),
                Price = 101,
                Date = DateTime.UtcNow,
                Profile = {
                    Email = "TestEpost",
                    Name = "TestNamn",
                    RoleId = Guid.NewGuid(),
                    PhoneNumber = "1234567890",
                    ImageSrc = "TestImageSrc"
                },
                Address = {
                    Address = "TestAddress",
                    PostalCode = "12345",
                    City = "TestCity"
                },
                Products = new List<OrderProductModel>(),
                OrderStatus = "Order is placed",
                PaymentMethod = "TestPaymentMethod",
                Comment = "TestComment",
                Delivery = "TestDelivery",
                PromoCodes = new List<PromoCodeModel>()
            };
            _orderRepo.Setup(x => x.CreateOrder(It.IsAny<OrderModel>()));
            //_orderRepo.Setup(x => x.AddAsync(It.IsAny<OrderEntity>())).ReturnsAsync(order);

            // Act
            var result = await _orderService.CreateOrder(orderModel);
            

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OrderModel>(result);






        }
    }
}