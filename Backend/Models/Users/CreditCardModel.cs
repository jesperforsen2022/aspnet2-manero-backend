namespace Backend.Models.Users
{
    public class CreditCardModel
    {
        public string CardName { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public int CvvCode { get; set; }
    }
}
