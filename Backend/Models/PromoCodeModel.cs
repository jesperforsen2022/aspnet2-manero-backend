namespace Backend.Models
{
    public class PromoCodeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Discount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
