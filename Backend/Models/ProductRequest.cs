using Backend.Models.Entities;

namespace Backend.Models
{
    public class ProductRequest
    {
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ProductId { get; set; }
        public string? ImageName { get; set; }


        public static implicit operator ProductEntity(ProductRequest entity)
        {
            return new ProductEntity
            {
                Name = entity.Name,
                Price = entity.Price,
                Category = entity.Category,
                Description = entity.Description,
                ImageName = entity.ImageName
            };
        }
    }
}
