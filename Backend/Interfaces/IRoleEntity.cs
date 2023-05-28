using Backend.Models.Entities.User;

namespace Backend.Interfaces
{
    public interface IRoleEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
        ICollection<UserEntity>? Users { get; set; }
    }
}