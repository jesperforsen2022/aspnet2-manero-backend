using Backend.Interfaces;
using Backend.Models.Users;

namespace Backend.Models.Entities.User
{
    public class CreditCardEntity : ICreditCard
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set;}
        public int CvvCode { get; set; }
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
