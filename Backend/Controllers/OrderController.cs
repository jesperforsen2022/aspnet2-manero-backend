using Backend.Contexts;
using Backend.Models.Entities;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Services;
using Backend.Interfaces;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var ordersOfUser = await _orderService.GetOrder(email);
            return Ok(ordersOfUser);
        }


        [HttpPost]
        public async Task<IActionResult> Create(OrderModel order)
        {
            var orderEntity = await _orderService.CreateOrder(order);
            return Ok(orderEntity);
        }

    }
}
