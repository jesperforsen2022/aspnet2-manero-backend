using Backend.Models;
using Backend.Models.Entities.User;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Backend.Interfaces
{
    public interface IUserService
    {
        Task<bool> CheckUserExistsAsync(Expression<Func<UserEntity, bool>> predicate);
        Task<UserEntity> GetUserFromId(string userId);
        Task<UserEntity> GetUserFromToken(ClaimsPrincipal userClaims);
        Task<string> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(UserEntity user, string password);
        Task<bool> RegisterSocialAccountAsync(UserEntity user);
        Task<bool> UpdateProfileAsync(UserEntity user, UserProfileModel model);
    }
}