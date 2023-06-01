namespace Backend.Interfaces
{
    public interface ICreditCardModel
    {
        string CardName { get; set; }
        string CardNumber { get; set; }
        Guid CreditCardId { get; set; }
        string CvvCode { get; set; }
        string ExpireMonth { get; set; }
        string ExpireYear { get; set; }
    }
}