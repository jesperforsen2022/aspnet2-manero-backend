namespace Backend.Interfaces
{
    public interface IUser
    {
        public string Name { get; set; } 
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImageSrc { get; set; }
    }
}
