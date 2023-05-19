using Backend.Models.Entities;

namespace Backend.Interfaces.PromoCode
{
    public interface IPromoCodeService
    {
        Task<PromoCodeEntity> CreatePromoCodeAsync(string name, decimal discount, DateTime expiryDate);
        Task DeletePromoCodeAsync(Guid id);
        Task<List<PromoCodeEntity>> GetAllPromoCodesAsync();
    }
}
