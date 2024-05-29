using ProiectPAW.Data;
using ProiectPAW.Models;
using ProiectPAW.Repositories.Interfaces;

namespace ProiectPAW.Repositories
{
    public class ProviderRepository : RepositoryBase<Provider>, IProviderRepository
    {
        public ProviderRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
