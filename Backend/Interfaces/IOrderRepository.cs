using Backend.Models;
using Backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Interfaces
{
    public interface IOrderRepository
    {
        Task<IActionResult> CreateOrder(OrderModel order);
        Task<IActionResult> GetAllOrders();
        Task<IActionResult> GetOrder(string email);
    }
}