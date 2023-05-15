using Backend.Contexts;
using Backend.Models.Entities.User;

namespace Backend.Repositories.Users;

public class UserAddressRepository : GeneralRepository<UserAddressEntity>
{
    public UserAddressRepository(SqlContext context) : base(context)
    {
    }
}
