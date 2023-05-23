using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Contexts;
using Backend.Models;
using Backend.Models.Entities;


namespace Backend.Services
{
    public class PromoCodeService 
    {
        private readonly NoSqlContext _nosql;

        public PromoCodeService(NoSqlContext nosql)
        {
            _nosql = nosql;
        }

        public async Task<PromoCodeEntity> CreatePromoCodeAsync(PromoCodeModel pCodeModel)
        {
            PromoCodeEntity promoCode = new PromoCodeEntity
            {
                Id = Guid.NewGuid(),
                Name = pCodeModel.Name,
                Discount = pCodeModel.Discount,
                ExpiryDate = pCodeModel.ExpiryDate
            };
            _nosql.PromoCode.Add(promoCode);
            await _nosql.SaveChangesAsync();
            return promoCode;
        }

        public async Task<IActionResult> GetAllPromoCodesAsync()
        {
            var promoCodes = new List<PromoCodeModel>();
            foreach (var promoCode in await _nosql.PromoCode.ToListAsync())
                promoCodes.Add(new PromoCodeModel
                {
                    Id = promoCode.Id,
                    Name = promoCode.Name,
                    Discount = promoCode.Discount,
                    ExpiryDate = promoCode.ExpiryDate
                });
            return new OkObjectResult(promoCodes);

        }

        public async Task DeletePromoCodeAsync(Guid id)
        {
            var promoCode = await _nosql.PromoCode.FirstOrDefaultAsync(x => x.Id == id);
            if (promoCode != null)
            {
                _nosql.PromoCode.Remove(promoCode);
                await _nosql.SaveChangesAsync();
            }
        }
    }
}
