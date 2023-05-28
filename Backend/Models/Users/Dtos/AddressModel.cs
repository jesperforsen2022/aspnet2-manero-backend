using Backend.Interfaces;

namespace Backend.Models.Users.Dtos
{
    public class AddressModel : IAddressModel
    {
        public Guid AddressId { get; set; }
        public string Title { get; set; } = null!;

        public string StreetName { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string City { get; set; } = null!;

    }
}
