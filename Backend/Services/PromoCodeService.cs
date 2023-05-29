using Backend.Interfaces.PromoCode;
using Backend.Models.Entities;
using Backend.Models.Schemas;
using System.Diagnostics;

namespace Backend.Services
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly IPromoCodeRepo _pCRepo;

        public PromoCodeService(IPromoCodeRepo pCRepo)
        {
            _pCRepo = pCRepo;
        }

        public async Task<PromoCodeEntity> CreateAsync(PromoCodeSchema pCSchema)
        {
            try
            {
                if (pCSchema != null)
                {
                    return await _pCRepo.AddAsync(pCSchema);
                }

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<IEnumerable<PromoCodeEntity>> GetAllAsync()
        {
            try
            {
                return await _pCRepo.GetAllAsync();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<PromoCodeEntity> DeleteAsync(Guid id)
        {
            try
            {
                return await _pCRepo.DeleteAsync(id);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }
    }

}
