using ProiectPAW.Models;
using System.Collections.Generic;

namespace ProiectPAW.Services.Interfaces
{
    public interface IUserInfoService
    {
        void CreateUserInfo(UserInfo UserInfo);

        void DeleteUserInfo(UserInfo UserInfo);

        void UpdateUserInfo(UserInfo UserInfo);
        UserInfo GetUserInfoById(int id);

        List<UserInfo> GetUserInfos();
        UserInfo GetUserInfoByUserId(string id);
    }
}