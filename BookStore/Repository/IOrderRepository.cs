using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        List<Order> GetOrdersByAccountId(int accountId);
        Order GetOrderById(int id);
        Order AddOrder(Order o);
        void UpdateOrder(Order o);
        void DeleteOrder(Order o);
    }
}
