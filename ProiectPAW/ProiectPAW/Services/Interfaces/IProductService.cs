using ProiectPAW.Models;
using System.Collections.Generic;

namespace ProiectPAW.Services.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(Product product);

        void DeleteProduct(Product product);

        void UpdateProduct(Product product);

        Product GetProductById(int id);

        List<Product> GetProducts();
    }
}