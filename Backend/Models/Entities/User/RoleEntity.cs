using Backend.Interfaces;

namespace Backend.Models.Entities.User
{
    public class RoleEntity : IRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<UserEntity>? Users { get; set; }
    }
}
