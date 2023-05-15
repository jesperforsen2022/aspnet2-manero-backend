using Backend.Contexts;
using Backend.Models.Entities.User;

namespace Backend.Repositories.Users
{
    public class CreditCardRepository : GeneralRepository<CreditCardEntity>
    {
        public CreditCardRepository(SqlContext context) : base(context)
        {
        }
    }
}
