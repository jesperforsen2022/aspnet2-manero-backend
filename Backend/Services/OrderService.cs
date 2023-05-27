using Backend.Contexts;
using Backend.Models.Entities;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Repositories;

namespace Backend.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepo;

        public OrderService(OrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<IActionResult> GetAllOrders()
        {
            return await _orderRepo.GetAllOrders();
        }

        public async Task<IActionResult> GetOrder(string email)
        {
            return await _orderRepo.GetOrder(email);
        }

        public async Task<IActionResult> CreateOrder(OrderModel order)
        {
            return await _orderRepo.CreateOrder(order);
        }

    }
}
