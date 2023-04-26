using Backend.Models.Entities;

namespace Backend.Models
{
    public class ProductRequest
    {
        public string Name { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public decimal Price { get; set; }

        public static implicit operator ProductEntity(ProductRequest entity)
        {
            return new ProductEntity
            {
                Name = entity.Name,
                Price = entity.Price,
                CategoryName = entity.CategoryName,
                Description = entity.Description,


            };
        }
    }
}
