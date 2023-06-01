namespace Backend.Interfaces
{
    public interface IOrderAddressModel
    {
        string Address { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
    }
}