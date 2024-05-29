using ProiectPAW.Services.Interfaces;
using ProiectPAW.Repositories.Interfaces;
using Microsoft.DotNet.Scaffolding.Shared;
using ProiectPAW.Models;
using System.Collections.Generic;


namespace ProiectPAW.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProviderService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateProvider(Provider provider)
        {
            _repositoryWrapper.ProviderRepository.Create(provider);
            _repositoryWrapper.Save();
        }

        public void DeleteProvider(Provider provider)
        {
            _repositoryWrapper.ProviderRepository.Delete(provider);
            _repositoryWrapper.Save();
        }

        public void UpdateProvider(Provider provider)
        {
            _repositoryWrapper.ProviderRepository.Update(provider);
            _repositoryWrapper.Save();
        }

        public Provider GetProviderById(int id)
        {
            return _repositoryWrapper.ProviderRepository.FindByCondition(c => c.providerID == id).FirstOrDefault()!;
        }

        public List<Provider> GetProviderByName(string Name)
        {
            return _repositoryWrapper.ProviderRepository.FindAll().ToList();//nu e functia buna, trebuie facuta
        }
        public List<Provider> GetProviders()
        {
            return _repositoryWrapper.ProviderRepository.FindAll().ToList();
        }

    }
}