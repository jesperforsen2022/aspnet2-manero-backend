namespace Backend.Models.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] Password { get; set; } = null!; 
        public byte[] SecurityKey { get; set; } = null!;
        public Guid ProfileId { get; set; }
        public UserProfileEntity Profile { get; set; } = null!;

    }
}
