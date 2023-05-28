using Backend.Contexts;
using Backend.Interfaces;
using Backend.Models.Entities.User;

namespace Backend.Repositories.Users;

public class RoleRepositoty : GeneralRepository<RoleEntity>, IRoleRepository
{
    public RoleRepositoty(SqlContext context) : base(context)
    {
    }
}
