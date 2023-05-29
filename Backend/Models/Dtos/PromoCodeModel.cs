using Backend.Interfaces.PromoCode;

namespace Backend.Models.Dtos
{
    public class PromoCodeModel : IPromoCodeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Discount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
