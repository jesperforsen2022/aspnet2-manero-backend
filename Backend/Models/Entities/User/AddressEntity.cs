using Backend.Interfaces;

namespace Backend.Models.Entities.User;

public class AddressEntity : IAddress
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public ICollection<UserAddressEntity>? UserAddress { get; set; }

}
