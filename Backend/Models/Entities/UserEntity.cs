using System.Security.Cryptography;
using System.Text;

namespace Backend.Models.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = null!;
        public byte[] Password { get; private set; } = null!; 
        public byte[] SecurityKey { get; private set; } = null!;
        public Guid ProfileId { get; set; }
        public UserProfileEntity Profile { get; set; } = null!;

        public void SetSecurePassword(string password)
        {
            using var hmac = new HMACSHA512();
            SecurityKey = hmac.Key;
            Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool ValidateSecurePassword(string password)
        {
            using var hmac= new HMACSHA512(SecurityKey);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != Password[i])
                    return false;
            }

            return true;
        }

    }
}
