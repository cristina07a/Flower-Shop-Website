using ProiectPAW.Services.Interfaces;
using ProiectPAW.Repositories.Interfaces;
using ProiectPAW.Models;
using System.Collections.Generic;


namespace ProiectPAW.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProductService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateProduct(Product product)
        {
            _repositoryWrapper.ProductRepository.Create(product);
            _repositoryWrapper.Save();
        }

        public void DeleteProduct(Product product)
        {
            _repositoryWrapper.ProductRepository.Delete(product);
            _repositoryWrapper.Save();
        }

        public void UpdateProduct(Product product)
        {
            _repositoryWrapper.ProductRepository.Update(product);
            _repositoryWrapper.Save();
        }

        public Product GetProductById(int id)
        {
            return _repositoryWrapper.ProductRepository.FindByCondition(c => c.productID == id).FirstOrDefault()!;
        }

        public List<Product> GetProductByName(string Name)
        {
            return _repositoryWrapper.ProductRepository.FindAll().ToList();//nu e functia buna, trebuie facuta
        }
        public List<Product> GetProducts()
        {
            return _repositoryWrapper.ProductRepository.FindAll().ToList();
        }

    }
}