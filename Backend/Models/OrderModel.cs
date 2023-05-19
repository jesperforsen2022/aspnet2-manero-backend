using Backend.Models.Entities;

namespace Backend.Models
{
    public class OrderModel
    {
        public decimal? Price { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public UserProfileModel Profile { get; set; } = null!;
        public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
        public string? OrderStatus { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string? Comment { get; set; }
        public string Delivery { get; set; } = null!;
        public List<PromoCodeEntity>? PromoCodes { get; set; } = new List<PromoCodeEntity>();
    }
}
