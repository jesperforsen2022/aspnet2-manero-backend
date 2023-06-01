using Backend.Interfaces;
using Backend.Models.Entities.User;
using Backend.Repositories.Users;
using Backend.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manero.Test.UnitTests.Per
{
    public class AddressService_Tests__Per
    {
        private Mock<IAddressRepository> _addressRepository;
        private Mock<IUserRepository> _userRepository;
        private Mock<IUserAddressRepository> _userAddressRepository;
        private AddressService _addressService;

        public AddressService_Tests__Per()
        {
            _addressRepository = new Mock<IAddressRepository>();
            _userRepository = new Mock<IUserRepository>();
            _userAddressRepository = new Mock<IUserAddressRepository>();
            _addressService = new AddressService(_addressRepository.Object, _userRepository.Object, _userAddressRepository.Object);
        }

        [Fact]
        public async Task RegisterAddressAsync__Should_Create_New_Address_And_Return_True()
        {
            //Arrange
            AddressEntity address = new()
            {
                Id = Guid.NewGuid(),
                Title = "Test",
                StreetName = "Testgatan 1",
                PostalCode = "12345",
                City = "Testby",
            };

            UserEntity user = new()
            {
                Id = "123",
                RoleId = Guid.NewGuid(),
                Name = "Testy Testsson",
                Email = "testy_t@testia.com",
                IsSocialAccount = false,
                Provider = "local"
            };
            _addressRepository.Setup(x => x.AddAsync(It.IsAny<AddressEntity>())).ReturnsAsync(address);

            //Act
            var result = await _addressService.RegisterAddressAsync(user, address);

            //Assert
            Assert.IsType<bool>(result);
            Assert.True(result);

        }
    }    
    
}
