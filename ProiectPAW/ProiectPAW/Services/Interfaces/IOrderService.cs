using ProiectPAW.Models;
using System.Collections.Generic;

namespace ProiectPAW.Services.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(Order order);

        void DeleteOrder(Order order);

        void UpdateOrder(Order order);
        Order GetOrderById(int id);

        List<Order> GetOrders();

        public Order GetOrderByUserId(string id);

        public Order GetActiveOrderByUserId(string id);
    }
}