using Backend.Interfaces;
using Backend.Models.Users.Dtos;

namespace Backend.Models.Entities.User
{
    public class CreditCardEntity : ICreditCardEntity
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = null!;
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public string ExpireMonth { get; set; } = null!;
        public string ExpireYear { get; set; } = null!;
        public string CvvCode { get; set; } = null!;
        public UserEntity User { get; set; } = null!;

        public static implicit operator CreditCardModel(CreditCardEntity entity)
        {
            return new CreditCardModel
            {
                CreditCardId = entity.Id,
                CardName = entity.CardName,
                CardNumber = entity.CardNumber,
                ExpireMonth = entity.ExpireMonth,
                ExpireYear = entity.ExpireYear,
                CvvCode = entity.CvvCode
            };
        }
    }
}
