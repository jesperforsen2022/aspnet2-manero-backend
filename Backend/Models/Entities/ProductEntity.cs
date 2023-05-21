using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Cosmos.Linq;

namespace Backend.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public string? Description { get; set; }
        public string? Specification { get; set; }
        public string? ImageName { get; set; }
        public string? Color { get; set; }
        public string? Gender { get; set; }

        public List<string> Size { get; set; } = new List<string>();

        public List<string> Tags { get; set; } = new List<string>();


        public static implicit operator Product(ProductEntity entity)
        {
            return new Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Category = entity.Category,
                Description = entity.Description,
                ImageName = entity.ImageName,
                Color = entity.Color,
                Gender = entity.Gender,
                Size = entity.Size,
                Tags = entity.Tags
            };
        }

    }
}
