using ProiectPAW.Data;
using ProiectPAW.Models;
using ProiectPAW.Repositories.Interfaces;

namespace ProiectPAW.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
