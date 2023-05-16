using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPut("editprofile")]
        public async Task<IActionResult> EditProfile(UserProfileModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userService.GetUserFromToken(User);
                if(await _userService.UpdateProfileAsync(user, model))
                {
                    return Ok("Profile updated");
                }
                else
                {
                    return BadRequest("Couldnt update profile");
                }
            }
            return BadRequest();
        }

        [HttpGet("addresses")]
        public async Task<IActionResult> GetAllAddresses()
        {
            var user = await _userService.GetUserFromToken(User);
            if(user == null)
            {
                return Unauthorized();
            }

            var addresses = await _userService.GetAllAddressesForUser(user);
            if(addresses == null || !addresses.Any())
            {
                return NotFound("No addreses found for the user");
            }
            return Ok(addresses);
        }
    }
}
