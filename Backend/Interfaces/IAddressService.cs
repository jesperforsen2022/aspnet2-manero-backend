using Backend.Models.Entities.User;
using Backend.Models.Users.Dtos;
using System.Security.Claims;

namespace Backend.Interfaces
{
    public interface IAddressService
    {
        Task<List<AddressModel>> GetAllAddressesForUser(UserEntity user);
        Task<UserEntity> GetUserFromToken(ClaimsPrincipal userClaims);
        Task<bool> RegisterAddressAsync(UserEntity user, AddressEntity address);
        Task<bool> UpdateUserAddressAsync(UserEntity user, Guid addressId, AddressModel newAddress);
    }
}