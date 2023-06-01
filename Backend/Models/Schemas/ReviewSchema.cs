using Backend.Models.Entities;

namespace Backend.Models.Schemas
{
    public class ReviewSchema : IReviewSchema
    {
        public string? Reviewer { get; set; }
        public string? Review { get; set; }
        public decimal? RatingStar { get; set; }
        public DateTime? ReviewDate { get; set; }


        public static implicit operator ReviewSchema(ReviewEntity entity)
        {
            if (entity != null)
                return new ReviewSchema
                {
                    Reviewer = entity.Reviewer,
                    Review = entity.Review,
                    RatingStar = entity.RatingStar,
                    ReviewDate = entity.ReviewDate
                };

            return null!;
        }
    }
}
