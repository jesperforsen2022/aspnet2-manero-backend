using Backend.Models.Entities.User;
using Backend.Models.Users.Dtos;
using System.Security.Claims;

namespace Backend.Interfaces
{
    public interface ICreditCardService
    {
        Task<List<CreditCardModel>> GetAllCreditCardsForUser(UserEntity user);
        Task<UserEntity> GetUserFromToken(ClaimsPrincipal userClaims);
        Task<bool> RegisterCreditCardAsync(UserEntity user, CreditCardEntity creditCard);
    }
}