namespace Backend.Models
{
    public class ProductReviewModel
    {
        public string ProductSKU { get; set; } = string.Empty;
        public string? Comment { get; set; }
        public int Rating { get; set; }
    }
}
