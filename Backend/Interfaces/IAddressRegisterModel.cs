namespace Backend.Interfaces
{
    public interface IAddressRegisterModel
    {
        string City { get; set; }
        string PostalCode { get; set; }
        string StreetName { get; set; }
        string Title { get; set; }
    }
}