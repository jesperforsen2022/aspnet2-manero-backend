using Backend.Interfaces;
using Backend.Models.Users.Dtos;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Models.Entities.User
{
    public class UserEntity : IUserEntity
    {
        public string Id { get; set; } = null!;
        public Guid RoleId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? ImageSrc { get; set; }

        public bool IsSocialAccount { get; set; } = false;
        public string Provider { get; set; } = "local";

        public ICollection<CreditCardEntity>? CreditCards { get; set; }
        public RoleEntity Role { get; set; } = null!;
        public ICollection<UserAddressEntity>? UserAddress { get; set; }
        public byte[]? Password { get; private set; }
        public byte[]? SecurityKey { get; private set; }

        public void SetSecurePassword(string password)
        {
            using var hmac = new HMACSHA512();
            SecurityKey = hmac.Key;
            Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool ValidateSecurePassword(string password)
        {
            using var hmac = new HMACSHA512(SecurityKey!);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < hash.Length; i++)
            {
                if (hash[i] != Password![i])
                    return false;
            }

            return true;
        }

        public static implicit operator UserProfileModel(UserEntity entity)
        {
            return new UserProfileModel
            {
                Email = entity.Email,
                Name = entity.Name,
                RoleId = entity.RoleId,
                PhoneNumber = entity.PhoneNumber,
                ImageSrc = entity.ImageSrc,
            };
        }

    }
}
