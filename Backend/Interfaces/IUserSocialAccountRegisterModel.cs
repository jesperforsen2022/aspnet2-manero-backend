namespace Backend.Interfaces
{
    public interface IUserSocialAccountRegisterModel
    {
        string Email { get; set; }
        string Id { get; set; }
        string? ImageSrc { get; set; }
        bool IsSocialAccount { get; set; }
        string Name { get; set; }
        string Provider { get; set; }
    }
}