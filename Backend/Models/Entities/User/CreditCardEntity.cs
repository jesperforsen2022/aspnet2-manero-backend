using Backend.Interfaces;

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
    }
}
