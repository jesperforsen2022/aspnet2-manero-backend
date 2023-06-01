using Backend.Interfaces;
using Backend.Models.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Users.Schemas
{
    public class CreditCardRegisterModel : ICreditCardRegisterModel
    {
        [Required]
        public string CardName { get; set; } = null!;
        [Required]
        public string CardNumber { get; set; } = null!;
        [Required]
        public string ExpireMonth { get; set; } = null!;
        [Required]
        public string ExpireYear { get; set; } = null!;
        [Required]
        public string CvvCode { get; set; } = null!;

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
