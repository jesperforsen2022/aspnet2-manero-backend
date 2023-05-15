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
        //Kollar om adressen redan finns i databasen 
        var existingAddress = await _addressRepo.GetAsync(x =>
        x.Title == address.Title &&
        x.StreetName == address.StreetName &&
        x.PostalCode == address.PostalCode &&
        x.City == address.City);

        //Om addressen inte finns i databasen
        if(existingAddress == null)
        {
            //Skapa Id och lägg till addressen i databasen
            address.Id = Guid.NewGuid();
            await _addressRepo.AddAsync(address);

            //Skapa koppling mellan användaren och addressen 
            var userAddress = new UserAddressEntity
            {
                UserId = user.Id,
                AddressId = address.Id
            };

            //Lägg till kopplingen i kopplingstabellen
            await _userAddressRepo.AddAsync(userAddress);

            return true;
        }
        else //Om addressen finns i databasen
        {
            //Kolla om addressen redan är kopplad till användarem
            var existingUserAddress = await _userAddressRepo.GetAsync(x =>
            x.AddressId == existingAddress.Id &&
            x.UserId == user.Id);

            //Om addressen inte är kopplad till användaren
            if(existingUserAddress == null)
            {
                //Skapa kopplingen till användaren
                var userAddress = new UserAddressEntity
                {
                    UserId = user.Id,
                    AddressId = existingAddress.Id
                };

                //Lägg till kopplingen i kopplingstabellen
                await _userAddressRepo.AddAsync(userAddress);
            }
            return true;
        }
        
    }
}
