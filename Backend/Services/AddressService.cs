using Backend.Interfaces;
using Backend.Models.Entities.User;
using Backend.Models.Users.Dtos;
using System.Security.Claims;

namespace Backend.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepo;
    private readonly IUserRepository _userRepo;
    private readonly IUserAddressRepository _userAddressRepo;

    public AddressService(IAddressRepository addressRepo, IUserRepository userRepo, IUserAddressRepository userAddressRepo)
    {
        _addressRepo = addressRepo;
        _userRepo = userRepo;
        _userAddressRepo = userAddressRepo;
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
    public async Task<bool> RegisterAddressAsync(UserEntity user, AddressEntity address)
    {
        var existingAddress = await _addressRepo.GetAsync(x =>
        x.Title == address.Title &&
        x.StreetName == address.StreetName &&
        x.PostalCode == address.PostalCode &&
        x.City == address.City);

        if (existingAddress == null)
        {
            address.Id = Guid.NewGuid();
            await _addressRepo.AddAsync(address);

            var userAddress = new UserAddressEntity
            {
                UserId = user.Id,
                AddressId = address.Id
            };

            await _userAddressRepo.AddAsync(userAddress);

            return true;
        }
        else
        {
            var existingUserAddress = await _userAddressRepo.GetAsync(x =>
            x.AddressId == existingAddress.Id &&
            x.UserId == user.Id);

            if (existingUserAddress == null)
            {
                var userAddress = new UserAddressEntity
                {
                    UserId = user.Id,
                    AddressId = existingAddress.Id
                };

                await _userAddressRepo.AddAsync(userAddress);
            }
            return true;
        }

    }
    public async Task<List<AddressModel>> GetAllAddressesForUser(UserEntity user)
    {
        if (user != null)
        {
            var userAddresses = await _userAddressRepo.GetAllAsync(x => x.UserId == user.Id);
            var addressModels = new List<AddressModel>();

            foreach (var userAddress in userAddresses)
            {
                var addressEntity = await _addressRepo.GetAsync(x => x.Id == userAddress.AddressId);
                if (addressEntity != null)
                {
                    AddressModel addressModel = addressEntity;
                    addressModels.Add(addressModel);
                }
            }
            return addressModels;

        }
        return new List<AddressModel>();
    }

    public async Task<bool> UpdateUserAddressAsync(UserEntity user, Guid addressId, AddressModel newAddress)
    {
        if (user != null && newAddress != null)
        {
            var userAddresses = await _userAddressRepo.GetAsync(x => x.UserId == user.Id && x.AddressId == addressId);

            if (userAddresses != null)
            {
                await _userAddressRepo.RemoveRangeAsync(userAddresses);

                var newAddressEntity = new AddressEntity
                {
                    Id = Guid.NewGuid(),
                    Title = newAddress.Title,
                    StreetName = newAddress.StreetName,
                    PostalCode = newAddress.PostalCode,
                    City = newAddress.City
                };
                await _addressRepo.AddAsync(newAddressEntity);

                var newUserAddress = new UserAddressEntity
                {
                    UserId = user.Id,
                    AddressId = newAddressEntity.Id,
                };
                await _userAddressRepo.AddAsync(newUserAddress);

                return true;
            }
        }
        return false;
    }

}
