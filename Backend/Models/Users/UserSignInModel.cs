using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Users;

public class UserSignInModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    public bool RememberMe { get; set; } = false;
}
