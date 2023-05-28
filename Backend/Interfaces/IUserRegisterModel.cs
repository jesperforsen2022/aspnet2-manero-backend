namespace Backend.Interfaces
{
    public interface IUserRegisterModel
    {
        string Email { get; set; }
        string Name { get; set; }
        string Password { get; set; }
    }
}