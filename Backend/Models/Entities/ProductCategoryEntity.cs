namespace Backend.Models.Entities
{
    public class ProductCategoryEntity
    {
        //public int Id { get; set; }

        // Ikue added line 7-12
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Specification { get; set; }


        public string CategoryName { get; set; } = null!;
        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();

        
    }
}
