using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Interfaces
{
    public interface IOrderService
    {
        Task<IActionResult> CreateOrder(OrderModel order);
        Task<IActionResult> GetAllOrders();
        Task<IActionResult> GetOrder(string email);
    }
}