using Backend.Interfaces;
using Backend.Models.Users;

namespace Backend.Models.Entities.User;

public class AddressEntity : IAddress
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public ICollection<UserAddressEntity>? UserAddress { get; set; }

    public static implicit operator AddressModel(AddressEntity entity)
    {
        return new AddressModel
        {
            AddressId = entity.Id,
            Title = entity.Title,
            StreetName = entity.StreetName,
            PostalCode = entity.PostalCode,
            City = entity.City,
        };
    }

}
