namespace Backend.Models
{
    public class OrderProductModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public string? Gender { get; set; }
        public string? Size { get; set; }
        public string? Image { get; set; }
        public decimal? Quantity { get; set; }
    }
}
