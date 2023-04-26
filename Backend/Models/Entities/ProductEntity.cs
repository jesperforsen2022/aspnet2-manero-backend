using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public string PartitionKey { get; set; } = "Product";


        public static implicit operator ProductModel(ProductEntity entity)
        {
            return new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                CategoryName = entity.CategoryName,
                Description = entity.Description,

                
            };
        }

    }
}
