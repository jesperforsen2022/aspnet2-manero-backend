using Backend.Interfaces;

namespace Backend.Models.Users.Dtos
{
    public class CreditCardModel : ICreditCardModel
    {
        public Guid CreditCardId { get; set; }
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public string ExpireMonth { get; set; } = null!;
        public string ExpireYear { get; set; } = null!;
        public string CvvCode { get; set; } = null!;
    }
}
