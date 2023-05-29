namespace Backend.Interfaces
{
    public interface ICreditCardRegisterModel
    {
        string CardName { get; set; }
        string CardNumber { get; set; }
        string CvvCode { get; set; }
        string ExpireMonth { get; set; }
        string ExpireYear { get; set; }
    }
}