using Backend.Contexts;
using Backend.Models.Entities;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Repositories;
using Backend.Interfaces;

namespace Backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public virtual async Task<IActionResult> GetAllOrders()
        {
            return await _orderRepo.GetAllOrders();
        }

        public virtual async Task<IActionResult> GetOrder(string email)
        {
            return await _orderRepo.GetOrder(email);
        }

        public virtual async Task<IActionResult> CreateOrder(OrderModel order)
        {
            return await _orderRepo.CreateOrder(order);
        }

    }
}
