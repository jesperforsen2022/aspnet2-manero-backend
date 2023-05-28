using Backend.Models.Entities;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Backend.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Backend.Services;

namespace Backend.Repositories
{
    public class OrderRepository
    {
        private readonly NoSqlContext _nosql;

        public OrderRepository(NoSqlContext nosql)
        {
            _nosql = nosql;
        }


        public async Task<IActionResult> GetAllOrders()
        {
            var orders = new List<OrderModel>();
            foreach (var order in await _nosql.Orders.ToListAsync())
            {
                orders.Add(new OrderModel
                {
                    Id = order.Id,
                    Price = order.Price,
                    Date = order.Date,
                    Profile = order.Profile,
                    Products = order.Products,
                    OrderStatus = order.OrderStatus,
                    PaymentMethod = order.PaymentMethod,
                    Comment = order.Comment,
                    Delivery = order.Delivery,
                    PromoCodes = order.PromoCodes
                });
            }
            return new OkObjectResult(orders);
        }

        public async Task<IActionResult> GetOrder(string email)
        {
            var ordersOfUser = new List<OrderModel>();

            foreach (var order in await _nosql.Orders.ToListAsync())
            {
                if (order.Profile.Email == email)
                {
                    ordersOfUser.Add(new OrderModel
                    {
                        Id = order.Id,
                        Price = order.Price,
                        Date = order.Date,
                        Profile = order.Profile,
                        Products = order.Products,
                        OrderStatus = order.OrderStatus,
                        PaymentMethod = order.PaymentMethod,
                        Comment = order.Comment,
                        Delivery = order.Delivery,
                        PromoCodes = order.PromoCodes
                    });
                }
            }
            return new OkObjectResult(ordersOfUser);
        }

        public async Task<IActionResult> CreateOrder(OrderModel order)
        {
            OrderEntity orderEntity = new()
            {
                Price = order.Price,
                Profile = order.Profile,
                Products = order.Products,
                PaymentMethod = order.PaymentMethod,
                Comment = order.Comment,
                Delivery = order.Delivery,
                PromoCodes = order.PromoCodes
            };
            _nosql.Orders.Add(orderEntity);
            await _nosql.SaveChangesAsync();
            return new OkObjectResult(orderEntity);
        }
    }
}
