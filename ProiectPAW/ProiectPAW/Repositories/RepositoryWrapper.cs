using ProiectPAW.Data;
using ProiectPAW.Repositories.Interfaces;
namespace ProiectPAW.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        protected ApplicationDbContext _applicationDbContext { get; set; }
        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        //Category
        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_applicationDbContext);
                }
                return _categoryRepository;
            }
        }

        //Order
        private IOrderRepository _orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_applicationDbContext);
                }
                return _orderRepository;
            }
        }

        //ProductImage
        private IProductImageRepository _productImageRepository;
        public IProductImageRepository ProductImageRepository
        {
            get
            {
                if (_productImageRepository == null)
                {
                    _productImageRepository = new ProductImageRepository(_applicationDbContext);
                }
                return _productImageRepository;
            }
        }

        //ProductImage
        private IUserInfoRepository _userInfoRepository;
        public IUserInfoRepository UserInfoRepository
        {
            get
            {
                if (_userInfoRepository == null)
                {
                    _userInfoRepository = new UserInfoRepository(_applicationDbContext);
                }
                return _userInfoRepository;
            }
        }

        //Product
        private IProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_applicationDbContext);
                }
                return _productRepository;
            }
        }

        //OrderProduct
        private IOrderProductRepository _orderProductRepository;
        public IOrderProductRepository OrderProductRepository
        {
            get
            {
                if (_orderProductRepository == null)
                {
                    _orderProductRepository = new OrderProductRepository(_applicationDbContext);
                }
                return _orderProductRepository;
            }
        }

        //Provider
        private IProviderRepository _providerRepository;
        public IProviderRepository ProviderRepository
        {
            get
            {
                if (_providerRepository == null)
                {
                    _providerRepository = new ProviderRepository(_applicationDbContext);
                }
                return _providerRepository;
            }
        }

        //Review
        private IReviewRepository _reviewRepository;
        public IReviewRepository ReviewRepository
        {
            get
            {
                if (_reviewRepository == null)
                {
                    _reviewRepository = new ReviewRepository(_applicationDbContext);
                }
                return _reviewRepository;
            }
        }

        //User
        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_applicationDbContext);
                }
                return _userRepository;
            }
        }
    }

}