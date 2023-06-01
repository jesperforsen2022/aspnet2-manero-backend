using Backend.Models.Schemas;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<IActionResult> GetAll()
        {
            var list = await _reviewService.GetAllAsync();

            return Ok(list);
        }

        public async Task<IActionResult> CreateReview(ReviewSchema reviewSchema)
        {

            var review = await _reviewService.CreateAsync(reviewSchema);

            return Ok(review);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var review = await _reviewService.DeleteAsync(id);

            return Ok(review);
        }

    }
}
