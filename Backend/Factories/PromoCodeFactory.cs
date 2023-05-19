using Backend.Interfaces.PromoCode;
using Backend.Models.Entities;

namespace Backend.Factories
{
    public class PromoCodeFactory : IPromoCodeFactory
    {
        public PromoCodeEntity Create(string name, decimal discount, DateTime expiryDate)
        {
            return new PromoCodeEntity
            {
                Name = name,
                Discount = discount,
                ExpiryDate = expiryDate
            };
        }
    }
}
