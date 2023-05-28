using Backend.Interfaces;
using Backend.Models.Entities.User;
using Backend.Models.Users.Dtos;
using System.Security.Claims;

namespace Backend.Services;

public class CreditCardService : ICreditCardService
{
    private readonly ICreditCardRepository _creditCardRepo;
    private readonly IUserRepository _userRepo;

    public CreditCardService(ICreditCardRepository creditCardRepo, IUserRepository userRepo)
    {
        _creditCardRepo = creditCardRepo;
        _userRepo = userRepo;
    }

    public async Task<UserEntity> GetUserFromToken(ClaimsPrincipal userClaims)
    {
        var userIdClaim = userClaims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            throw new ArgumentException("Invalid user token");
        }

        var user = await _userRepo.GetAsync(x => x.Id == userIdClaim.Value);

        if (user == null)
        {
            throw new ArgumentException("User not found");
        }

        return user;
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

        else
        {
            return false;
        }

    }

    public async Task<List<CreditCardModel>> GetAllCreditCardsForUser(UserEntity user)
    {
        if (user != null)
        {
            var creditCardModels = new List<CreditCardModel>();


            var creditCardEntities = await _creditCardRepo.GetAllAsync(x => x.UserId == user.Id);
            foreach (var creditCardEntity in creditCardEntities)
            {
                if (creditCardEntity != null)
                {
                    CreditCardModel creditCardModel = creditCardEntity;
                    creditCardModels.Add(creditCardModel);
                }
            }

            return creditCardModels;

        }

        return new List<CreditCardModel>();
    }
}
