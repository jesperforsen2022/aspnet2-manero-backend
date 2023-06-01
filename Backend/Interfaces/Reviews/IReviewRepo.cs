using Backend.Models.Entities;
using Backend.Repositories;

namespace Backend.Interfaces.Reviews
{
    public interface IReviewRepo : IReviweRepository<ReviewEntity>
    {
    }
}
