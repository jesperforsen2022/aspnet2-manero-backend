namespace Backend.Models.Entities
{
    public class ReviewEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal? RatingStar { get; set; } = 0;

        public List<ReviewModel>? Reviews { get; set; } = new List<ReviewModel>();
    }
}
