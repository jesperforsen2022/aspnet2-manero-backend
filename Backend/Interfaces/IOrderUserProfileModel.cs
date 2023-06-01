namespace Backend.Interfaces
{
    public interface IOrderUserProfileModel
    {
        string? Email { get; set; }
        string? ImageSrc { get; set; }
        string? Name { get; set; }
        string? PhoneNumber { get; set; }
        Guid? RoleId { get; set; }
    }
}