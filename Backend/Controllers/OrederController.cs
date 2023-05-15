using Backend.Contexts;
using Backend.Models.Entities;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrederController : ControllerBase
    {
        private readonly NoSqlContext _nosql;

        public OrederController(NoSqlContext nosql)
        {
            _nosql = nosql;
        }

       




    }
}
