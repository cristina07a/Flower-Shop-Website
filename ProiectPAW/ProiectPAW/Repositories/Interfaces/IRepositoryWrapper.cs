using ProiectPAW.Repositories.Interfaces;

namespace ProiectPAW.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository CategoryRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderProductRepository OrderProductRepository { get; }
        IProviderRepository ProviderRepository { get; }
        IUserRepository UserRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IUserInfoRepository UserInfoRepository { get; }

        void Save();
    }
}
