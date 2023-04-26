namespace Backend.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageName { get; set; } = null!;

    }
}
