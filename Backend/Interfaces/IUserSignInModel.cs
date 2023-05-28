namespace Backend.Interfaces
{
    public interface IUserSignInModel
    {
        string Email { get; set; }
        string Password { get; set; }
        bool RememberMe { get; set; }
    }
}