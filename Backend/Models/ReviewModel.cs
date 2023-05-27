using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ReviewModel
    {
        public string? Reviewer { get; set; }
        public string? Review { get; set; }
        public decimal? RatingStar { get; set; }
        public DateTime? ReviewDate { get; set; }
    }
}
