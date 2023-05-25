namespace Backend.Models.Entities
{
    public class ReviewEntity
    {
        public float? RatingStar { get; set; }
        public List<float>? RatingStarList { get; set; } = new List<float>();
        public List<string>? Review { get; set; } = new List<string>();
    }
}
