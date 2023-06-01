using Backend.Interfaces;
using Backend.Models.Entities.User;
using Backend.Models.Users.Dtos;
using Backend.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Manero.Test.UnitTests.Per
{
    public class UserService_Tests__Per
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<IRoleRepository> _roleRepository;
        private IUserService _userService;

        public UserService_Tests__Per() 
        { 
            _userRepository = new Mock<IUserRepository>();
            _roleRepository = new Mock<IRoleRepository>();
            _userService = new UserService(_userRepository.Object, _roleRepository.Object);
        }


        [Fact]
        public async Task UpdateProfileAsync__Should_Update_User_And_Return_True()
        {
            //Arrange
            UserEntity user = new()
            {
                Id = "123",
                RoleId = Guid.NewGuid(),
                Name = "Testy Testsson",
                Email = "testy_t@testia.com",
                IsSocialAccount = false,
                Provider = "local"
            };

            UserProfileModel model = new()
            {
                Email = "testy_t-t@testdata.tst",
                Name = "Testy Testsson-Test",
                RoleId = Guid.NewGuid(),
                PhoneNumber = "1111111111",
            };
            _userRepository.Setup(x => x.UpdateAsync(It.IsAny<UserEntity>()));
            //Act

            var result = await _userService.UpdateProfileAsync(user, model);


            //Assert

            Assert.IsType<bool>(result);
            Assert.True(result);
            
        }
    }

    
}
