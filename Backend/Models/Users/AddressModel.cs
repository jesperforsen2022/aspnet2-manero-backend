using Backend.Models.Entities.User;

namespace Backend.Models.Users
{
    public class AddressModel
    {
        public Guid AddressId { get; set; }
        public string Title { get; set; } = null!;
  
        public string StreetName { get; set; } = null!;
      
        public string PostalCode { get; set; } = null!;
        
        public string City { get; set; } = null!;

    }
}
