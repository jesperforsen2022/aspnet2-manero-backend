namespace Backend.Models.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal? Price { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public UserProfileModel Profile { get; set; } = null!;
        public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
        public string? OrderStatus { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public List<PromoCodeEntity> PromoCodes { get; set; } = new List<PromoCodeEntity>();
    }
}
