using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities
{
    public class ReviewEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Reviewer { get; set; } = null!;
        public string? Review { get; set; }

        [Required]
        public decimal RatingStar { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
    }
}
