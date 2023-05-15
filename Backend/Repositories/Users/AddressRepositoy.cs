using Backend.Contexts;
using Backend.Models.Entities.User;

namespace Backend.Repositories.Users
{
    public class AddressRepositoy : GeneralRepository<AddressEntity>
    {
        public AddressRepositoy(SqlContext context) : base(context)
        {
        }
    }
}
