using Backend.Interfaces;
using Backend.Models.Users.Schemas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [Route("api/address")]
    [ApiController]
    [Authorize]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;


        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("register")] 
        public async Task<IActionResult> RegisterAddress(AddressRegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _addressService.GetUserFromToken(User);

                if (await _addressService.RegisterAddressAsync(user, model))
                {
                    return Ok("Address registered successfully");
                }
                else
                {
                    return BadRequest("Failed to register address");
                }

            }
            return BadRequest("Invalid address data");
        }

        [HttpGet("addresses")]
        public async Task<IActionResult> GetAllAddresses()
        {
            var user = await _addressService.GetUserFromToken(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var addresses = await _addressService.GetAllAddressesForUser(user);
            if (addresses == null || !addresses.Any())
            {
                return NotFound("No addreses found for the user");
            }
            return Ok(addresses);
        }

    }
}
