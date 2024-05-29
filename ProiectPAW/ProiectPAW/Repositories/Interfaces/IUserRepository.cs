using Microsoft.AspNetCore.Identity;
using ProiectPAW.Models;
using ProiectPAW.Repositories.Interfaces;

namespace ProiectPAW.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<IdentityUser>
    {
    }
}
