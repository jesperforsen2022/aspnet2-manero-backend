using Backend.Interfaces.PromoCode;
using Backend.Models.Entities;

namespace Backend.Models.Schemas
{
    public class PromoCodeSchema : IPromoCodeSchema
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Discount { get; set; }
        public DateTime ExpiryDate { get; set; }


        public static implicit operator PromoCodeEntity(PromoCodeSchema promoCodeSchema)
        {
            if (promoCodeSchema != null)
                return new PromoCodeEntity
                {
                    Id = promoCodeSchema.Id,
                    Name = promoCodeSchema.Name,
                    Discount = promoCodeSchema.Discount,
                    ExpiryDate = promoCodeSchema.ExpiryDate
                };

            return null!;
        }
    }
}
