using Backend.Models.Entities.User;
using Backend.Repositories.Users;

namespace Backend.Services;

public class CreditCardService
{
    private readonly CreditCardRepository _creditCardRepo;

    public CreditCardService(CreditCardRepository creditCardRepo)
    {
        _creditCardRepo = creditCardRepo;
    }

    public async Task<bool> RegisterCreditCardAsync(UserEntity user, CreditCardEntity creditCard)
    {

        if (creditCard != null)
        {
            creditCard.Id = Guid.NewGuid();
            creditCard.UserId = user.Id;
            await _creditCardRepo.AddAsync(creditCard);

            return true;
        }
        else { return false; }

    }
}
