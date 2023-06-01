using Backend.Models;
using Backend.Models.Dtos;

namespace Backend.Interfaces
{
    public interface IOrderModel
    {
        OrderAddressModel? Address { get; set; }
        string? Comment { get; set; }
        DateTime? Date { get; set; }
        string Delivery { get; set; }
        Guid Id { get; set; }
        string? OrderStatus { get; set; }
        string PaymentMethod { get; set; }
        decimal Price { get; set; }
        List<OrderProductModel>? Products { get; set; }
        OrderUserProfileModel? Profile { get; set; }
        List<PromoCodeModel>? PromoCodes { get; set; }
    }
}