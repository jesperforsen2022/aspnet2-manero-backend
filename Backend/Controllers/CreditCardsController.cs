using Backend.Interfaces;
using Backend.Models.Users.Schemas;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/creditcard")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCreditCard(CreditCardRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _creditCardService.GetUserFromToken(User);

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

        [HttpGet("creditcards")]
        public async Task<IActionResult> GetAllCreditCards()
        {
            var user = await _creditCardService.GetUserFromToken(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var creditCards = await _creditCardService.GetAllCreditCardsForUser(user);
            if (creditCards == null || !creditCards.Any())
            {
                return NotFound("No creditcards found for the user");
            }

            return Ok(creditCards);
        }
    }

}
