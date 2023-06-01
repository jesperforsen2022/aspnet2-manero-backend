using Backend.Interfaces;

namespace Backend.Models
{
    public class OrderAddressModel : IOrderAddressModel
    {
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
