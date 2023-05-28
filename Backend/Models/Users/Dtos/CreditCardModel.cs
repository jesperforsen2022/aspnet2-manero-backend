using Backend.Interfaces;

namespace Backend.Models.Users.Dtos
{
    public class CreditCardModel : ICreditCardModel
    {
        public Guid CreditCardId { get; set; }
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int CvvCode { get; set; }
    }
}
