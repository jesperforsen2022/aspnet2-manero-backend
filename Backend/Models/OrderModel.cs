using Backend.Models.Entities;

namespace Backend.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public UserProfileModel Profile { get; set; } = null!;
        public List<OrderProductModel> Products { get; set; } = new List<OrderProductModel>();
        public string? OrderStatus { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string? Comment { get; set; }
        public string Delivery { get; set; } = null!;
        public List<PromoCodeModel>? PromoCodes { get; set; } = new List<PromoCodeModel>();
    }
}
