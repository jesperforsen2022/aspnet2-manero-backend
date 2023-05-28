using Backend.Interfaces;
using Backend.Models.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Users.Schemas;

public class AddressRegisterModel : IAddressRegisterModel
{
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string StreetName { get; set; } = null!;
    [Required]
    public string PostalCode { get; set; } = null!;
    [Required]
    public string City { get; set; } = null!;

    public static implicit operator AddressEntity(AddressRegisterModel model)
    {
        return new AddressEntity
        {
            Title = model.Title,
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City = model.City,
        };
    }
}
