using Backend.Models.Entities;
using Backend.Models.Schemas;

namespace Backend.Interfaces.PromoCode
{
    public interface IPromoCodeService
    {
        Task<PromoCodeEntity> CreateAsync(PromoCodeSchema pCSchema);
        Task<PromoCodeEntity> DeleteAsync(Guid id);
        Task<IEnumerable<PromoCodeEntity>> GetAllAsync();
    }
}