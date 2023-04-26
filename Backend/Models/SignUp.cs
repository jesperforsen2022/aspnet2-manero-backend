using Backend.Models.Entities;

namespace Backend.Models
{
    public class SignUp
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public static implicit operator UserEntity(SignUp form)
        {
            var userEntity = new UserEntity
            {
                Email = form.Email,
                Profile = new UserProfileEntity
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    PhoneNumber = form.PhoneNumber ?? "",
                    StreetName = form.StreetName ?? "",
                    PostalCode = form.PostalCode ?? "",
                    City = form.City ?? ""
                }
            };

            userEntity.ProfileId = userEntity.Profile.Id;
            userEntity.SetSecurePassword(form.Password);

            return userEntity;

        }
    }
}
