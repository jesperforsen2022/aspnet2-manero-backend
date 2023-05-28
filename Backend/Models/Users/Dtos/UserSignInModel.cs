using System.ComponentModel.DataAnnotations;
using Backend.Interfaces;

namespace Backend.Models.Users.Dtos;

public class UserSignInModel : IUserSignInModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    public bool RememberMe { get; set; } = false;
}
