using Backend.Interfaces.Reviews;
using Backend.Models.Entities;
using Backend.Models.Schemas;
using System.Diagnostics;

namespace Backend.Services
{
    public class ReviewService /*: IReviewService*/
    {
        private readonly IReviewRepo _reviewRepo;

        public ReviewService(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }


        public async Task<IEnumerable<ReviewEntity>> GetAllAsync()
        {
            try
            {
                return await _reviewRepo.GetAllAsync();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        public async Task<ReviewEntity> DeleteAsync(Guid id)
        {
            try
            {
                return await _reviewRepo.DeleteAsync(id);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        //public async Task<ReviewEntity> CreateAsync(ReviewSchema reviewSchema)
        //{
        //    try
        //    {
        //        if (reviewSchema != null)
        //        {
        //            var reviewEntity = new ReviewEntity
        //            {
        //                Name = reviewSchema.Name,
        //                Rating = reviewSchema.Rating,
        //                Comment = reviewSchema.Comment,
        //                CreatedAt = reviewSchema.CreatedAt
        //            };

        //            return await _reviewRepo.AddAsync(reviewEntity);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }

        //      return null!;
        //}

        //public async Task<ReviewEntity> UpdateReviewAsync(Guid id, ReviewSchema reviewSchema)
        //{
        //    try
        //    {
        //        if (reviewSchema != null)
        //        {
        //            var reviewEntity = new ReviewEntity
        //            {
        //                Name = reviewSchema.Name,
        //                Rating = reviewSchema.Rating,
        //                Comment = reviewSchema.Comment,
        //                CreatedAt = reviewSchema.CreatedAt
        //            };

        //            return await _reviewRepo.UpdateAsync(id, reviewEntity);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }

        //    return null!;
        //}
    }
}
