using ProiectPAW.Services.Interfaces;
using ProiectPAW.Repositories.Interfaces;
using ProiectPAW.Models;
using System.Collections.Generic;


namespace ProiectPAW.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public OrderService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateOrder(Order order)
        {
            _repositoryWrapper.OrderRepository.Create(order);
            _repositoryWrapper.Save();
        }

        public void DeleteOrder(Order order)
        {
            _repositoryWrapper.OrderRepository.Delete(order);
            _repositoryWrapper.Save();
        }

        public void UpdateOrder(Order order)
        {
            _repositoryWrapper.OrderRepository.Update(order);
            _repositoryWrapper.Save();
        }

        public Order GetOrderById(int id)
        {
            return _repositoryWrapper.OrderRepository.FindByCondition(c => c.orderID == id).FirstOrDefault()!;
        }

        public List<Order> GetOrderByName(string Name)
        {
            return _repositoryWrapper.OrderRepository.FindAll().ToList();//nu e functia buna, trebuie facuta
        }

        public List<Order> GetOrders()
        {
            return _repositoryWrapper.OrderRepository.FindAll().ToList();
        }

        public Order GetOrderByUserId(string id)
        {
            return _repositoryWrapper.OrderRepository.FindByCondition(c => c.userID == id).FirstOrDefault()!;
        }


        public Order GetActiveOrderByUserId(string id)
        {
            return _repositoryWrapper.OrderRepository.FindByCondition(c => c.userID == id && c.status == "Active").FirstOrDefault()!;
        }
    }
}