using ProiectPAW.Services.Interfaces;
using ProiectPAW.Repositories.Interfaces;
using ProiectPAW.Models;
using System.Collections.Generic;


namespace ProiectPAW.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ReviewService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateReview(Review review)
        {
            _repositoryWrapper.ReviewRepository.Create(review);
            _repositoryWrapper.Save();
        }

        public void DeleteReview(Review review)
        {
            _repositoryWrapper.ReviewRepository.Delete(review);
            _repositoryWrapper.Save();
        }

        public void UpdateReview(Review review)
        {
            _repositoryWrapper.ReviewRepository.Update(review);
            _repositoryWrapper.Save();
        }

        public Review GetReviewById(int id)
        {
            return _repositoryWrapper.ReviewRepository.FindByCondition(c => c.reviewID == id).FirstOrDefault()!;
        }

        public List<Review> GetReviewByName(string Name)
        {
            return _repositoryWrapper.ReviewRepository.FindAll().ToList();//nu e functia buna, trebuie facuta
        }

        public List<Review> GetReviews()
        {
            return _repositoryWrapper.ReviewRepository.FindAll().ToList();
        }

    }
}