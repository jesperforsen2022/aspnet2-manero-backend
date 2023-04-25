namespace Backend.Models
{
    public class ProductModel
    {
        public string SKU { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string LongDescription { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public decimal Price { get; set; }
        public IEnumerable<ProductReviewModel> Reviews { get; set; } = null!;

        public double Rating()
        {
            if (Reviews != null)
            {
                var rating = 0;

                foreach (var review in Reviews)
                    rating += review.Rating;

                return rating / Reviews.Count();
            }

            return 0;
        }
    }
}
