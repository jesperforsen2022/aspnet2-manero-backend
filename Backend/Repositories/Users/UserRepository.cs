using Backend.Contexts;
using Backend.Interfaces;
using Backend.Models.Entities.User;

namespace Backend.Repositories.Users
{
    public class UserRepository : GeneralRepository<UserEntity>, IUserRepository
    {
        public UserRepository(SqlContext context) : base(context)
        {
        }

    }
}
