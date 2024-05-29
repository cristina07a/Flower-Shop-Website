using ProiectPAW.Data;
using ProiectPAW.Models;
using ProiectPAW.Repositories.Interfaces;

namespace ProiectPAW.Repositories
{
    public class OrderProductRepository : RepositoryBase<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
