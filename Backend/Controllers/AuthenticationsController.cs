using Backend.Contexts;
using Backend.Models;
using Backend.Models.Entities.User;
using Backend.Models.Users;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;

namespace Backend.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthenticationsController(UserService userService)
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
                var user = await _userService.GetUserFromId(model.Id);
                if (await _userService.CheckUserExistsAsync(x => x.Id == model.Id))
                {

                    return Ok(new { Token = TokenGenerator.GenerateJwtToken(user) });                   
                  
                }

                if (await _userService.RegisterSocialAccountAsync(model))
                {
                    return Created("", model);
                }

                //var (success, token) = await _userService.RegisterSocialAccountAsync(model);
                //if (success)
                //{
                //    return Created("", token);
                //}
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
