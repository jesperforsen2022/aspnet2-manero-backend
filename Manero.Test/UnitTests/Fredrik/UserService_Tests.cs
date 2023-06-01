using Backend.Interfaces;
using Backend.Models.Entities.User;
using Backend.Services;
using Moq;
using System.Linq.Expressions;

namespace Manero.Test.UnitTests.Fredrik;

public class UserService_Tests
{
    private Mock<IUserRepository> _userRepo;
    private Mock<IRoleRepository> _roleRepo;
    private IUserService _userService;

    public UserService_Tests()
    {
        _userRepo = new Mock<IUserRepository>();
        _roleRepo = new Mock<IRoleRepository>();
        _userService = new UserService(_userRepo.Object, _roleRepo.Object);
    }

    [Fact]

    public async Task GetUserFromID__Should_Return_Specific_UserEntity_Based_On_Id()
    {
        //Arrange
        UserEntity entity = new UserEntity
        {
            Id = "1234123412341234",
            RoleId = Guid.NewGuid(),
            Email = "fredrik@test.com",
            Name = "Fredrik Jung",
            IsSocialAccount = true,
            Provider = "facebook"
        };

        _userRepo.Setup(x => x.GetAsync(It.IsAny<Expression<Func<UserEntity, bool>>>())).ReturnsAsync(entity);


        //Act
        var result = await _userService.GetUserFromId("1234123412341234");

        //Assert
        Assert.NotNull(result);
        Assert.IsType<UserEntity>(result);
        Assert.Equal(entity.Id, result.Id);
    }
}
