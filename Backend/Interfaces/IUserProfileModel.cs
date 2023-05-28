namespace Backend.Interfaces
{
    public interface IUserProfileModel
    {
        string Email { get; set; }
        string? ImageSrc { get; set; }
        string Name { get; set; }
        string? PhoneNumber { get; set; }
        Guid RoleId { get; set; }
    }
}