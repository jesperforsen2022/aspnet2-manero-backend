using Backend.Models.Users;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/creditcard")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly CreditCardService _creditCardService;

        public CreditCardsController(UserService userService, CreditCardService creditCardService)
        {
            _userService = userService;
            _creditCardService = creditCardService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCreditCard(CreditCardRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserFromToken(User);

                if (await _creditCardService.RegisterCreditCardAsync(user, model))
                {
                    return Ok("Creditcard registered successfully");
                }
                else
                {
                    return BadRequest("Failed to register creditcard");
                }

            }
            return BadRequest("Invalid creditcard data");
        }
    }

}
