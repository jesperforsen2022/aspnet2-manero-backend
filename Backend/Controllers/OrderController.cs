using Backend.Contexts;
using Backend.Models.Entities;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly NoSqlContext _nosql;

        public OrderController(NoSqlContext nosql)
        {
            _nosql = nosql;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = new List<OrderEntity>();
            foreach (var order in await _nosql.Orders.ToListAsync())
                orders.Add(new OrderEntity
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
            return Ok(orders);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var ordersOfUser = new List<OrderEntity>();

            foreach (var order in await _nosql.Orders.ToListAsync()) 
            { 
                if (order.Profile.Email == email) 
                {
                    ordersOfUser.Add(new OrderEntity
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
            return Ok(ordersOfUser);
        }


        [HttpPost]
        public async Task<IActionResult> Create(OrderEntity order)
        {
            OrderEntity orderEntity = order;
            _nosql.Orders.Add(orderEntity);
            await _nosql.SaveChangesAsync();
            return Ok(orderEntity);
        }

    }
}
