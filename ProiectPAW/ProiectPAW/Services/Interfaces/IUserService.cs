using Microsoft.AspNetCore.Identity;
using ProiectPAW.Models;
using System.Collections.Generic;

namespace ProiectPAW.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(IdentityUser user);

        void DeleteUser(IdentityUser user);

        void UpdateUser(IdentityUser user);
        IdentityUser GetUserById(string id);

        List<IdentityUser> GetUsers();
    }
}