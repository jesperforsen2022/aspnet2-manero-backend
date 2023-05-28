using Backend.Interfaces;

namespace Backend.Models.Users.Dtos
{
    public class UserProfileModel : IUserProfileModel
    {
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Guid RoleId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImageSrc { get; set; }

    }
}
