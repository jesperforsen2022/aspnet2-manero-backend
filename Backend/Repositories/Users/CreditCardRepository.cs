using Backend.Contexts;
using Backend.Interfaces;
using Backend.Models.Entities.User;

namespace Backend.Repositories.Users
{
    public class CreditCardRepository : GeneralRepository<CreditCardEntity>, ICreditCardRepository
    {
        public CreditCardRepository(SqlContext context) : base(context)
        {
        }
    }
}
