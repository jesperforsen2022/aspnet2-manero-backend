using Backend.Interfaces;
using Backend.Models.Entities.User;
using Backend.Models.Users.Dtos;
using Backend.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manero.Test.UnitTests.Fadi
{
    public class AddressService_Tests
    {
        
        private readonly Mock<IAddressRepository> _addressRepoMock;
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly Mock<IUserAddressRepository> _userAddressRepoMock;
        private readonly AddressService _addressService;

        public AddressService_Tests()
        {
            _addressRepoMock = new Mock<IAddressRepository>();
            _userRepoMock = new Mock<IUserRepository>();
            _userAddressRepoMock = new Mock<IUserAddressRepository>();
            _addressService = new AddressService(_addressRepoMock.Object, _userRepoMock.Object, _userAddressRepoMock.Object);
        }

        [Fact]
        public async Task UpdateUserAddressAsync_Should_Return_False_When_User_Or_Address_Is_Null()
        {
            // Arrange
            var user = new UserEntity { Id = "1" };
            var addressId = Guid.NewGuid();
            AddressModel newAddress = null;

            // Act
            var result = await _addressService.UpdateUserAddressAsync(user, addressId, newAddress);

            // Assert
            Assert.False(result);
            _userAddressRepoMock.Verify(x => x.RemoveRangeAsync(It.IsAny<UserAddressEntity>()), Times.Never);
            _addressRepoMock.Verify(x => x.AddAsync(It.IsAny<AddressEntity>()), Times.Never);
            _userAddressRepoMock.Verify(x => x.AddAsync(It.IsAny<UserAddressEntity>()), Times.Never);
        }
    }
}
