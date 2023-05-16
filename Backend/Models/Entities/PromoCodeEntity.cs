using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities
{
    public class PromoCodeEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public decimal Discount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
