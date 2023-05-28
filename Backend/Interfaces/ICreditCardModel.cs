namespace Backend.Interfaces
{
    public interface ICreditCardModel
    {
        string CardName { get; set; }
        string CardNumber { get; set; }
        Guid CreditCardId { get; set; }
        int CvvCode { get; set; }
        int ExpireMonth { get; set; }
        int ExpireYear { get; set; }
    }
}