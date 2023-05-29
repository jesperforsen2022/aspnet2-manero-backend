using Backend.Models.Dtos;

namespace Backend.Models.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Price { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public UserProfileModel Profile { get; set; } = null!;
        public List<OrderProductModel> Products { get; set; } = new List<OrderProductModel>();
        public string OrderStatus { get; set; } = "Order is placed";
        public string PaymentMethod { get; set; } = null!;
        public string? Comment { get; set; }
        public string Delivery { get; set; } = null!;
        public List<PromoCodeModel>? PromoCodes { get; set; } = new List<PromoCodeModel>();
    }
}
