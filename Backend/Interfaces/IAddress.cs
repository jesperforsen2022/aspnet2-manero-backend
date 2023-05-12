namespace Backend.Interfaces
{
    public interface IAddress
    {
        public string Title { get; set; }
        public string StreetName { get; set; } 
        public string PostalCode { get; set; } 
        public string City { get; set; } 
    }
}
