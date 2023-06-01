namespace Backend.Models.Entities
{
    public interface IReviewEntity
    {
        Guid Id { get; set; }
        decimal RatingStar { get; set; }
        string? Review { get; set; }
        DateTime ReviewDate { get; set; }
        string Reviewer { get; set; }
    }
}