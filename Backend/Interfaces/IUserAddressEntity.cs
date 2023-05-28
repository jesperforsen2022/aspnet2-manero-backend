using Backend.Models.Entities.User;

namespace Backend.Interfaces
{
    public interface IUserAddressEntity
    {
        AddressEntity Address { get; set; }
        Guid AddressId { get; set; }
        UserEntity User { get; set; }
        string UserId { get; set; }
    }
}