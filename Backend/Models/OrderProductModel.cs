using Backend.Interfaces;

namespace Backend.Models
{
    public class OrderProductModel : IOrderProductModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public decimal? Price { get; set; }
        public decimal? Quantity { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public string? Gender { get; set; }
        public string? Size { get; set; }


    }
}
