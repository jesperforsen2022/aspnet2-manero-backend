using Backend.Models.Users;

namespace Backend.Models
{
    public class UserProfileModel
    {
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string StreetName { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string City { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? ImageSrc { get; set; }

    }
}
