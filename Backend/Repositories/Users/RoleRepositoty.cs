using Backend.Contexts;
using Backend.Models.Entities.User;

namespace Backend.Repositories.Users;

public class RoleRepositoty : GeneralRepository<RoleEntity>
{
    public RoleRepositoty(SqlContext context) : base(context)
    {
    }
}
