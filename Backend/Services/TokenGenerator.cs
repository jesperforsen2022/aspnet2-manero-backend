using Backend.Models.Entities.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Services
{
    public class TokenGenerator
    {
        private static readonly IConfiguration _configuration; 

        static TokenGenerator()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            _configuration = config.Build();
        }

        public static string GenerateJwtToken(UserEntity user)
        {
            var claims = new List<Claim>()
            {
                
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FullName", user.Name),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                //new Claim("PhoneNumber", user.PhoneNumber!),

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["TokenGenerator:Issuer"],
                Audience = _configuration["TokenGenerator:Audience"],
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenGenerator:Secret"]!)),
                SecurityAlgorithms.HmacSha512Signature),
                Subject = new ClaimsIdentity(claims)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(securityTokenDescriptor));
        }
    }
}
