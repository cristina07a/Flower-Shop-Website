using ProiectPAW.Models;
using System.Collections.Generic;

namespace ProiectPAW.Services.Interfaces
{
    public interface IProductImageService
    {
        void CreateProductImage(ProductImage productImage);

        void DeleteProductImage(ProductImage productImage);

        void UpdateProductImage(ProductImage productImage);

        ProductImage GetProductImageById(int id);
        List<ProductImage> GetProductImages();

    }
}