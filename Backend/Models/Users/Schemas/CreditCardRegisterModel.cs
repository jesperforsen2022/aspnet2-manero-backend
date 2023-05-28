using Backend.Interfaces;
using Backend.Models.Entities.User;

namespace Backend.Models.Users.Schemas
{
    public class CreditCardRegisterModel : ICreditCardRegisterModel
    {
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int CvvCode { get; set; }

        public static implicit operator CreditCardEntity(CreditCardRegisterModel model)
        {
            return new CreditCardEntity
            {
                CardName = model.CardName,
                CardNumber = model.CardNumber,
                ExpireMonth = model.ExpireMonth,
                ExpireYear = model.ExpireYear,
                CvvCode = model.CvvCode
            };
        }
    }
}
