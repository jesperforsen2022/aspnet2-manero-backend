using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Backend.Models.Forms
{
    public class SignInForm
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        public string ReturnUrl { get; set; } = null!;
    }
}
