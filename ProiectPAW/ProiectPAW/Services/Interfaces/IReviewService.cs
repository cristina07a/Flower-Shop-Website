using ProiectPAW.Models;
using System.Collections.Generic;

namespace ProiectPAW.Services.Interfaces
{
    public interface IReviewService
    {
        void CreateReview(Review review);

        void DeleteReview(Review review);

        void UpdateReview(Review review);
        Review GetReviewById(int id);

        List<Review> GetReviews();
    }
}