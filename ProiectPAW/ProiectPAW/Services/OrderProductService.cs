using ProiectPAW.Services.Interfaces;
using ProiectPAW.Repositories.Interfaces;
using ProiectPAW.Models;
using System.Collections.Generic;


namespace ProiectPAW.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public OrderProductService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateOrderProduct(OrderProduct order)
        {
            _repositoryWrapper.OrderProductRepository.Create(order);
            _repositoryWrapper.Save();
        }

        public void DeleteOrderProduct(OrderProduct order)
        {
            _repositoryWrapper.OrderProductRepository.Delete(order);
            _repositoryWrapper.Save();
        }

        public void UpdateOrderProduct(OrderProduct order)
        {
            _repositoryWrapper.OrderProductRepository.Update(order);
            _repositoryWrapper.Save();
        }

        public OrderProduct GetOrderProductById(int id)
        {
            return _repositoryWrapper.OrderProductRepository.FindByCondition(c => c.OrderProductID == id).FirstOrDefault()!;
        }


        public List<OrderProduct> GetOrderProducts()
        {
            return _repositoryWrapper.OrderProductRepository.FindAll().ToList();
        }

        public List<OrderProduct> GetOrderProductsByOrderId(int id)
        {
            return _repositoryWrapper.OrderProductRepository.FindByCondition(c => c.OrderID == id).ToList();
        }

    }
}