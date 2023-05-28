namespace Backend.Interfaces
{
    public interface IAddressModel
    {
        Guid AddressId { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
        string StreetName { get; set; }
        string Title { get; set; }
    }
}