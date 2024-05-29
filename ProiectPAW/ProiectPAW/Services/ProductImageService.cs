using ProiectPAW.Services.Interfaces;
using ProiectPAW.Repositories.Interfaces;
using ProiectPAW.Models;
using System.Collections.Generic;


namespace ProiectPAW.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProductImageService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateProductImage(ProductImage productImage)
        {
            _repositoryWrapper.ProductImageRepository.Create(productImage);
            _repositoryWrapper.Save();
        }

        public void DeleteProductImage(ProductImage productImage)
        {
            _repositoryWrapper.ProductImageRepository.Delete(productImage);
            _repositoryWrapper.Save();
        }

        public void UpdateProductImage(ProductImage productImage)
        {
            _repositoryWrapper.ProductImageRepository.Update(productImage);
            _repositoryWrapper.Save();
        }

        public ProductImage GetProductImageById(int id)
        {
            return _repositoryWrapper.ProductImageRepository.FindByCondition(c => c.imageID == id).FirstOrDefault()!;
        }

        public List<ProductImage> GetProductImageByName(string Name)
        {
            return _repositoryWrapper.ProductImageRepository.FindAll().ToList();//nu e functia buna, trebuie facuta
        }

        public List<ProductImage> GetProductImages()
        {
            return _repositoryWrapper.ProductImageRepository.FindAll().ToList();
        }
    }
}