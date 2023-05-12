using Backend.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Models.Entities.User
{
    public class UserEntity : IUser
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? ImageSrc { get; set; }

        public ICollection <CreditCardEntity>? CreditCards { get; set; }
        public RoleEntity Roles { get; set; } = null!;
        public ICollection<UserAddressEntity>? UserAddress { get; set; }
        public byte[] Password { get; private set; } = null!;
        public byte[] SecurityKey { get; private set; } = null!;

        public void SetSecurePassword(string password)
        {
            using var hmac = new HMACSHA512();
            SecurityKey = hmac.Key;
            Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool ValidateSecurePassword(string password)
        {
            using var hmac = new HMACSHA512(SecurityKey);
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
