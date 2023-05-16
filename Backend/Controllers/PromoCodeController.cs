using Backend.Services;
using Microsoft.AspNetCore.Http;
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

        // [HttpGet]
        // GettAll

        [HttpPost("generate")]
        public IActionResult GeneratePromoCode()
        {
            var promoCode = _promoCodeService.GeneratePromoCode();

            return Ok (promoCode);
        }


        // [HttpDelete]
    }
}
