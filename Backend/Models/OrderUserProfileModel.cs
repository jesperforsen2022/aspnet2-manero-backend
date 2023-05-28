using Backend.Interfaces;

namespace Backend.Models
{
    public class OrderUserProfileModel
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public Guid? RoleId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImageSrc { get; set; }

    }
}
