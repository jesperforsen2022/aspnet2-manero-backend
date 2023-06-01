using Backend.Interfaces;
using Backend.Models.Entities.User;
using Backend.Models.Users.Schemas;
using Backend.Services;
using Moq;

namespace Manero.Test.UnitTests;

public class CreditCardService_Tests
{
    private ICreditCardService _creditCardService;

    public CreditCardService_Tests()
    {
        _creditCardRepo = new Mock
        _creditCardService = new CreditCardService();
    }

    [Fact]

    public async Task RegisterCreditCardAsync__Should_Create_New_CreditCardEntity_And_Return_True()
    {
        //Arrange
        CreditCardRegisterModel model = new CreditCardRegisterModel
        {
            CardName = "Fredrik Jung",
            CardNumber = "1234 5678 8765 4321",
            ExpireMonth = "04",
            ExpireYear = "27",
            CvvCode = "123"
        };

        CreditCardEntity entity = new CreditCardEntity
        {
            Id = Guid.NewGuid(),
            CardName = "Fredrik Jung",
            CardNumber = "1234 5678 8765 4321",
            ExpireMonth = "04",
            ExpireYear = "27",
            CvvCode = "123"
        };

        //Act
        var result = await _creditCardService.RegisterCreditCardAsync(model);

        //Assert
        Assert.NotNull(result);
        Assert.True(result);
    }
}
