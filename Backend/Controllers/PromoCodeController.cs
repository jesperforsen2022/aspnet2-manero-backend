using Backend.Interfaces.PromoCode;
using Backend.Models.Dtos;
using Backend.Models.Schemas;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodeController : ControllerBase
    {
        private readonly IPromoCodeService _promoCodeService;

        public PromoCodeController(IPromoCodeService promoCodeService)
        {
            _promoCodeService = promoCodeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _promoCodeService.GetAllAsync();

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PromoCodeSchema pCSchema)
        {

            var promoCode = await _promoCodeService.CreateAsync(pCSchema);

            return Ok(promoCode);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var promoCode = await _promoCodeService.DeleteAsync(id);

            return Ok(promoCode);
        }
    }
}