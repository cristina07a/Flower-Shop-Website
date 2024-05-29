using ProiectPAW.Models;
using System.Collections.Generic;

namespace ProiectPAW.Services.Interfaces
{
    public interface IProviderService
    {
        void CreateProvider(Provider provider);

        void DeleteProvider(Provider provider);

        void UpdateProvider(Provider provider);

        Provider GetProviderById(int id);
        List<Provider> GetProviders();
    }
}