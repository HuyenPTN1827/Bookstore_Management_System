using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImpRep
{
    public class OrderRepository : IOrderRepository
    {
        public Order AddOrder(Order o)
        {
            return OrderDAO.AddOrder(o);
        }

        public void DeleteOrder(Order o)
        {
            OrderDAO.DeleteOrder(o);
        }

        public Order GetOrderById(int id)
        {
            return OrderDAO.GetOrderById(id);
        }

        public List<Order> GetOrders()
        {
            return OrderDAO.GetOrders();
        }

        public List<Order> GetOrdersByAccountId(int accountId)
        {
            return OrderDAO.GetOrdersByAccountId(accountId);
        }

        public void UpdateOrder(Order o)
        {
            OrderDAO.UpdateOrder(o);
        }
    }
}
