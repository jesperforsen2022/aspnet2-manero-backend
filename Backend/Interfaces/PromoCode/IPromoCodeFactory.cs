using Backend.Models.Entities;

namespace Backend.Interfaces.PromoCode
{
    public interface IPromoCodeFactory
    {
        PromoCodeEntity Create(string name, decimal discount, DateTime expiryDate);
    }
}
