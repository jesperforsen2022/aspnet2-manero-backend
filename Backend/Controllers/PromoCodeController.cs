using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodeController : ControllerBase
    {
        private readonly PromoCodeService _promoCodeService;

        public PromoCodeController(PromoCodeService promoCodeService)
        {
            _promoCodeService = promoCodeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _promoCodeService.GetAllPromoCodesAsync();

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PromoCodeModel promocode)
        {

            var promoCode = await _promoCodeService.CreatePromoCodeAsync(promocode);

            return Ok(promoCode);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _promoCodeService.DeletePromoCodeAsync(id);

            return Ok();
        }
    }
}