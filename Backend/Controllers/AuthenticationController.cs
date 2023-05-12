using Backend.Contexts;
using Backend.Models;
using Backend.Models.Entities.User;
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


    }
}
