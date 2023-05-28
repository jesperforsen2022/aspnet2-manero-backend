namespace Backend.Interfaces
{
    public interface ICreditCardRegisterModel
    {
        string CardName { get; set; }
        string CardNumber { get; set; }
        int CvvCode { get; set; }
        int ExpireMonth { get; set; }
        int ExpireYear { get; set; }
    }
}