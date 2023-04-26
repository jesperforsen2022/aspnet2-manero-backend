using Backend.Contexts;
using Backend.Models;
using Backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SqlContext _sql;

        public AuthenticationController(SqlContext sql)
        {
            _sql = sql;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUp form)
        {
            UserEntity userEntity = form;

            _sql.Users.Add(userEntity);

            try
            {
                await _sql.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
    }
}
