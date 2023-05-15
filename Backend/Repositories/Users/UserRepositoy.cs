using Backend.Contexts;
using Backend.Models.Entities.User;

namespace Backend.Repositories.Users
{
    public class UserRepositoy : GeneralRepository<UserEntity>
    {
        public UserRepositoy(SqlContext context) : base(context)
        {
        }

    }
}
