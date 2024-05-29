using ProiectPAW.Data;
using ProiectPAW.Models;
using ProiectPAW.Repositories.Interfaces;

namespace ProiectPAW.Repositories
{
    public class UserInfoRepository : RepositoryBase<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
