using Backend.Models.Entities.User;
using Backend.Models.Users;
using Backend.Repositories.Users;
using System.Linq.Expressions;

namespace Backend.Services;

public class AddressService
{
    private readonly AddressRepositoy _addressRepo;
    private readonly UserRepositoy _userRepo;
    private readonly UserAddressRepository _userAddressRepo;

    public AddressService(AddressRepositoy addressRepo, UserRepositoy userRepo, UserAddressRepository userAddressRepo)
    {
        _addressRepo = addressRepo;
        _userRepo = userRepo;
        _userAddressRepo = userAddressRepo;
    }
    public async Task<bool> RegisterAddressAsync(UserEntity user, AddressEntity address)
    {

        var existingAddress = await _addressRepo.GetAsync(x =>
        x.Title == address.Title &&
        x.StreetName == address.StreetName &&
        x.PostalCode == address.PostalCode &&
        x.City == address.City);

        if(existingAddress == null)
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

            if(existingUserAddress == null)
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
}
