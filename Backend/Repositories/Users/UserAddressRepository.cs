using Backend.Contexts;
using Backend.Interfaces;
using Backend.Models.Entities.User;

namespace Backend.Repositories.Users;
public class UserAddressRepository : GeneralRepository<UserAddressEntity>, IUserAddressRepository
{
    public UserAddressRepository(SqlContext context) : base(context)
    {
    }
}
