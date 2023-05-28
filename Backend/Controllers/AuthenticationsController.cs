using Backend.Interfaces;
using Backend.Models.Users.Dtos;
using Backend.Models.Users.Schemas;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(UserRegisterModel model)
        {
            if(ModelState.IsValid)
            {
               
                
                if(await _userService.RegisterAsync(model, model.Password))
                {
                    return Created("", null);
                }
                return Conflict("A user with this email already exists");
            }
            return BadRequest("Email or password is not valid");
        }


        [HttpPost("socialaccountsignup")]
        public async Task<IActionResult> SocialAccountSignUp(UserSocialAccountRegisterModel model) 
        {
            if (ModelState.IsValid)
                
            {
                if (await _userService.CheckUserExistsAsync(x => x.Id == model.Id))
                {
                    var user = await _userService.GetUserFromId(model.Id);
                    var token = TokenGenerator.GenerateJwtToken(user);
                    return Ok(new { Token = token });

                }

                if (await _userService.RegisterSocialAccountAsync(model))
                {
                    var user = await _userService.GetUserFromId(model.Id);
                    var token = TokenGenerator.GenerateJwtToken(user);
                    return Ok(new { Token = token });
                }

            }
            return BadRequest("Something went wrong");
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(UserSignInModel model)
        {
            if(ModelState.IsValid)
            {
                if (await _userService.CheckUserExistsAsync(x => x.Email == model.Email))
                {
                    var result = await _userService.LoginAsync(model.Email, model.Password);
                    if(result != null)
                    {
                        return Ok(result);
                    }
                    
                }
                return Unauthorized("Incorrect email or password");
            }
            return Unauthorized("Incorrect email or password");
        }
       
    }
}
