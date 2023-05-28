using Backend.Models.Entities.User;

namespace Backend.Interfaces
{
    public interface IAddressEntity
    {
        string City { get; set; }
        Guid Id { get; set; }
        string PostalCode { get; set; }
        string StreetName { get; set; }
        string Title { get; set; }
        ICollection<UserAddressEntity>? UserAddress { get; set; }
    }
}