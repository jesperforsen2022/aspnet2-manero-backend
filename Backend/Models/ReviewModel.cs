namespace Backend.Models
{
    public class ReviewModel
    {
        public string? ReviewerEmail { get; set; }
        public string? Review { get; set; }
        public decimal? RatingStar { get; set; } = 0;

    }
}
