using Backend.Models.Entities;
using Backend.Models.Schemas;

namespace Backend.Services
{
    public interface IReviewService
    {
        Task<ReviewEntity> CreateAsync(ReviewSchema reviewSchema);
        Task<ReviewEntity> DeleteAsync(Guid id);
        Task<IEnumerable<ReviewEntity>> GetAllAsync();
    }
}