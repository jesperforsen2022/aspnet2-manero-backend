using Backend.Interfaces.PromoCode;
using Backend.Models.Entities;

namespace Backend.Services
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly IPromoCodeFactory _promoCodeFactory;
        private List<PromoCodeEntity> _promoCodes = new List<PromoCodeEntity>();

        public PromoCodeService(IPromoCodeFactory promoCodeFactory)
        {
            _promoCodeFactory = promoCodeFactory;
        }

        public async Task<PromoCodeEntity> CreatePromoCodeAsync(string name, decimal discount, DateTime expiryDate)
        {
            PromoCodeEntity promoCode = _promoCodeFactory.Create(name, discount, expiryDate);
            _promoCodes.Add(promoCode);
            return promoCode;
        }

        public async Task<List<PromoCodeEntity>> GetAllPromoCodesAsync()
        {
            return _promoCodes;
        }

        public async Task DeletePromoCodeAsync(Guid id)
        {
            PromoCodeEntity promoCode = _promoCodes.FirstOrDefault(x => x.Id == id)!;
            if (promoCode != null)
            {
                _promoCodes.Remove(promoCode);
            }
        }
    }
}
