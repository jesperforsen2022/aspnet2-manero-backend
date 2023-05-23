using Backend.Contexts;
using Backend.Models.Entities;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private readonly NoSqlContext _nosql;
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //var orders = new List<OrderModel>();
            //foreach (var order in await _nosql.Orders.ToListAsync())
            //    orders.Add(new OrderModel
            //    {
            //        Id = order.Id,
            //        Price = order.Price,
            //        Date = order.Date,
            //        Profile = order.Profile,
            //        Products = order.Products,
            //        OrderStatus = order.OrderStatus,
            //        PaymentMethod = order.PaymentMethod,
            //        Comment = order.Comment,
            //        Delivery = order.Delivery,
            //        PromoCodes = order.PromoCodes
            //    });
            //return Ok(orders);
            return Ok(_orderService.GetAllOrders());
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            //var ordersOfUser = new List<OrderModel>();

            //foreach (var order in await _nosql.Orders.ToListAsync()) 
            //{ 
            //    if (order.Profile.Email == email) 
            //    {
            //        ordersOfUser.Add(new OrderModel
            //        {
            //            Id = order.Id,
            //            Price = order.Price,
            //            Date = order.Date,
            //            Profile = order.Profile,
            //            Products = order.Products,
            //            OrderStatus = order.OrderStatus,
            //            PaymentMethod = order.PaymentMethod,
            //            Comment = order.Comment,
            //            Delivery = order.Delivery,
            //            PromoCodes = order.PromoCodes
            //        });
            //    }
            //}
            //return Ok(ordersOfUser);
            return Ok(_orderService.GetOrder(email));
        }


        [HttpPost]
        public async Task<IActionResult> Create(OrderModel order)
        {
            //OrderEntity orderEntity = new ()
            //{
            //    Id = Guid.NewGuid(),
            //    Price = order.Price,
            //    Date = order.Date,
            //    Profile = order.Profile,
            //    Products = order.Products,
            //    OrderStatus = order.OrderStatus,
            //    PaymentMethod = order.PaymentMethod,
            //    Comment = order.Comment,
            //    Delivery = order.Delivery,
            //    PromoCodes = order.PromoCodes
            //};
            //_nosql.Orders.Add(orderEntity);
            //await _nosql.SaveChangesAsync();
            //return Ok();
            return Ok(_orderService.CreateOrder(order));
        }

    }
}
