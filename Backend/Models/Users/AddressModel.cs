using Backend.Models.Entities.User;

namespace Backend.Models.Users
{
    public class AddressModel
    {
        public string Title { get; set; } = null!;
  
        public string StreetName { get; set; } = null!;
      
        public string PostalCode { get; set; } = null!;
        
        public string City { get; set; } = null!;

        public static implicit operator AddressEntity(AddressModel model)
        {
            return new AddressEntity
            {
                Title = model.Title,
                StreetName = model.StreetName,
                PostalCode = model.PostalCode,
                City = model.City,
            };
        }
    }
}
