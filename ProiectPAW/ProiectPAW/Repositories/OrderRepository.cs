using ProiectPAW.Data;
using ProiectPAW.Models;
using ProiectPAW.Repositories.Interfaces;

namespace ProiectPAW.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
