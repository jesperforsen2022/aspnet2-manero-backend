using Backend.Contexts;
using Backend.Interfaces;
using Backend.Models.Entities.User;

namespace Backend.Repositories.Users
{
    public class AddressRepository : GeneralRepository<AddressEntity>, IAddressRepository
    {
        public AddressRepository(SqlContext context) : base(context)
        {
        }
    }
}
