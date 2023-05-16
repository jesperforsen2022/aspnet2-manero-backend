using Backend.Models;
using Backend.Models.Entities.User;
using Backend.Models.Users;
using Backend.Repositories.Users;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers
{
    [Route("api/address")]
    [ApiController]
    [Authorize]
    public class AddressesController : ControllerBase
    {
        private readonly AddressService _addressService;
        private readonly UserService _userService;


        public AddressesController(AddressService addressService, UserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        [HttpPost("register")] 
        public async Task<IActionResult> RegisterAddress(AddressRegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userService.GetUserFromToken(User);

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

        [HttpPut("editaddress")]
        public async Task<IActionResult> EditAddress(AddressModel model, Guid id)
        {
            if (ModelState.IsValid)
            {
                var address = await _addressService.GetAddress(id);
                if (await _addressService.UpdateAddressAsync(address, model))
                {
                    return Ok("Address updated");
                }
                else
                {
                    return BadRequest("Couldnt update address");
                }
            }
            return BadRequest();
        }
    }
}
