using ProiectPAW.Models;
using System.Collections.Generic;

namespace ProiectPAW.Services.Interfaces
{
    public interface IOrderProductService
    {
        void CreateOrderProduct(OrderProduct orderProduct);

        void DeleteOrderProduct(OrderProduct orderProduct);

        void UpdateOrderProduct(OrderProduct orderProduct);

        OrderProduct GetOrderProductById(int id);

        List<OrderProduct> GetOrderProducts();

        List<OrderProduct> GetOrderProductsByOrderId(int id);
    }
}