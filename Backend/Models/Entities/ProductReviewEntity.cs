namespace Backend.Models.Entities
{
    public class ProductReviewEntity
    {
        public int Id { get; set; }
        public string ProductSKU { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }

        public ProductEntity Product { get; set; } = null!;
    }
}
