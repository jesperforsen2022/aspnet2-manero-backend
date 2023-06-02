using Backend.Interfaces;
using Backend.Models.Entities;

namespace Backend.Models
{
    public class ProductRequest : IProductRequest
    {
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ProductId { get; set; }
        public string? ImageName { get; set; }
        public float? RatingStar { get; set; }
        public string? Specification { get; set; }
        public string? Color { get; set; }
        public string? Gender { get; set; }

        public List<string> Size { get; set; } = new List<string>();
        public List<string> Tags { get; set; } = new List<string>();



        public static implicit operator ProductEntity(ProductRequest schema)
        {
            return new ProductEntity
            {
                Name = schema.Name,
                Price = schema.Price,
                Category = schema.Category,
                Description = schema.Description,
                ImageName = schema.ImageName,
                RatingStar = schema.RatingStar,
                Specification = schema.Specification,
                Color = schema.Color,
                Gender = schema.Gender,
                Size = schema.Size,
                Tags = schema.Tags
            };
        }
    }
}
