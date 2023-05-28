using Backend.Models.Entities.User;

namespace Backend.Interfaces
{
    public interface IUserEntity
    {
        ICollection<CreditCardEntity>? CreditCards { get; set; }
        string Email { get; set; }
        string Id { get; set; }
        string? ImageSrc { get; set; }
        bool IsSocialAccount { get; set; }
        string Name { get; set; }
        byte[]? Password { get; }
        string? PhoneNumber { get; set; }
        string Provider { get; set; }
        RoleEntity Role { get; set; }
        Guid RoleId { get; set; }
        byte[]? SecurityKey { get; }
        ICollection<UserAddressEntity>? UserAddress { get; set; }

        void SetSecurePassword(string password);
        bool ValidateSecurePassword(string password);
    }
}