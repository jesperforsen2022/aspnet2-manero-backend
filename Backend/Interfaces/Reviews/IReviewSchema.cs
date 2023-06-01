namespace Backend.Models.Schemas
{
    public interface IReviewSchema
    {
        decimal? RatingStar { get; set; }
        string? Review { get; set; }
        DateTime? ReviewDate { get; set; }
        string? Reviewer { get; set; }
    }
}