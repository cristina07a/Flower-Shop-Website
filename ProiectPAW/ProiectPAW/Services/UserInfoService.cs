using ProiectPAW.Services.Interfaces;
using ProiectPAW.Repositories.Interfaces;
using ProiectPAW.Models;
using System.Collections.Generic;


namespace ProiectPAW.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserInfoService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateUserInfo(UserInfo UserInfo)
        {
            _repositoryWrapper.UserInfoRepository.Create(UserInfo);
            _repositoryWrapper.Save();
        }

        public void DeleteUserInfo(UserInfo UserInfo)
        {
            _repositoryWrapper.UserInfoRepository.Delete(UserInfo);
            _repositoryWrapper.Save();
        }

        public void UpdateUserInfo(UserInfo UserInfo)
        {
            _repositoryWrapper.UserInfoRepository.Update(UserInfo);
            _repositoryWrapper.Save();
        }

        public UserInfo GetUserInfoById(int id)
        {
            return _repositoryWrapper.UserInfoRepository.FindByCondition(c => c.UserInfoID == id).FirstOrDefault()!;
        }

        public List<UserInfo> GetUserInfoByName(string Name)
        {
            return _repositoryWrapper.UserInfoRepository.FindAll().ToList();//nu e functia buna, trebuie facuta
        }

        public List<UserInfo> GetUserInfos()
        {
            return _repositoryWrapper.UserInfoRepository.FindAll().ToList();
        }

        public UserInfo GetUserInfoByUserId(string id)
        {
            return _repositoryWrapper.UserInfoRepository.FindByCondition(c => c.UserId == id).FirstOrDefault()!;
        }

    }
}