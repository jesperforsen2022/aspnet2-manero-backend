using Backend.Models.Users;

namespace Backend.Models
{
    public class UserProfileModel
    {
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Guid RoleId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImageSrc { get; set; }

    }
}
