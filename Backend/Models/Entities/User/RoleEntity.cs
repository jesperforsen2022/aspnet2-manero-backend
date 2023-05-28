using Backend.Interfaces;

namespace Backend.Models.Entities.User
{
    public class RoleEntity : IRoleEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<UserEntity>? Users { get; set; }
    }
}
