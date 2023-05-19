using Backend.Contexts;
using Backend.Models;
using Backend.Models.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodeController : ControllerBase
    {
        private readonly PromoCodeService _promoCodeService;
        private readonly NoSqlContext _nosql;

        public PromoCodeController(NoSqlContext nosql, PromoCodeService promoCodeService)
        {
            _nosql = nosql;
            _promoCodeService = promoCodeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var promoCodes = new List<PromoCodeEntity>();
            foreach (var promoCode in await _nosql.PromoCode.ToListAsync())
                promoCodes.Add(new PromoCodeEntity
                {
                    Id = promoCode.Id,
                    Name = promoCode.Name,
                    Discount = promoCode.Discount,
                    ExpiryDate = promoCode.ExpiryDate
                });
            //return new OkObjectResult(promoCodes);
            return Ok(promoCodes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PromoCodeEntity entity)
        {
            var promoCode = await _promoCodeService.CreatePromoCodeAsync(entity.Name, entity.Discount, entity.ExpiryDate);

            // Måste testas
            return Ok(promoCode);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _promoCodeService.DeletePromoCodeAsync(id);

            // Måste testas
            return Ok();
        }



        /*
            [HttpPost("generate")]
        public IActionResult GeneratePromoCode()
        {
            var promoCode = _promoCodeService.GeneratePromoCode();

            return Ok (promoCode);
        }
        */

        // [HttpDelete]
    }
}