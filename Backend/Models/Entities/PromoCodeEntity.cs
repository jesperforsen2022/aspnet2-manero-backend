using System.ComponentModel.DataAnnotations;
using Backend.Interfaces.PromoCode;

namespace Backend.Models.Entities
{
    public class PromoCodeEntity : IPromoCodeEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public decimal Discount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
