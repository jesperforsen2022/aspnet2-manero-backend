namespace Backend.Models.Entities.User
{
    public class UserAddressEntity
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public UserEntity User { get; set; } = null!;
        public AddressEntity Address { get; set; } = null!;
    }
}
