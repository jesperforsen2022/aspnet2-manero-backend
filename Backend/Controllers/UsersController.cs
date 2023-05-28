using Backend.Interfaces;
using Backend.Models.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
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

        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            
            var user = await _userService.GetUserFromToken(User);
            UserProfileModel model = user;
            if (model == null)
            {
                return Unauthorized();
            }

            return Ok(model);
        }

        [HttpGet("socialprofile")]
        public async Task<IActionResult> GetUserSocialProfile()
        {

            var user = await _userService.GetUserFromToken(User);
            UserProfileModel model = user;
            if (model == null)
            {
                return Unauthorized();
            }

            return Ok(model);
        }

    }
}
