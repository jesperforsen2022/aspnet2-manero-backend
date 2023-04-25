namespace Backend.Models.Identity
{
    public class AccountProfile
    {
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string? ImageName { get; set; }
    }
}
