using Backend.Contexts;
using Backend.Interfaces.Reviews;
using Backend.Models.Entities;

namespace Backend.Repositories.Review
{
    public class ReviewRepo : ReviewRepository<ReviewEntity>, IReviewRepo
    {
        public ReviewRepo(NoSqlContext context) : base(context)
        {
        }
    }
}
