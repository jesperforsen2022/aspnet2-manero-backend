using Backend.Interfaces;
using Backend.Models.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Users.Schemas
{
    public class UserSocialAccountRegisterModel : IUserSocialAccountRegisterModel
    {
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string? ImageSrc { get; set; }
        public bool IsSocialAccount { get; set; } = true;
        [Required]
        public string Provider { get; set; } = null!;

        public static implicit operator UserEntity(UserSocialAccountRegisterModel model)
        {
            return new UserEntity
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                ImageSrc = model.ImageSrc,
                IsSocialAccount = model.IsSocialAccount,
                Provider = model.Provider,
            };
        }

    }
}
