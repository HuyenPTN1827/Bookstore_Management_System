using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImpRep
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail od)
        {
            OrderDetailDAO.AddOrderDetail(od);
        }

        public void DeleteOrderDetail(OrderDetail od)
        {
            OrderDetailDAO.DeleteOrderDetail(od);
        }

        public List<OrderDetail> GetOrderDetailByBookId(int bookId)
        {
            return OrderDetailDAO.GetOrderDetailsByBookId(bookId);
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int orderId)
        {
            return OrderDetailDAO.GetOrderDetailsByOrderId(orderId);
        }

        public OrderDetail GetOrderDetailByOrderIdAndBookId(int orderId, int bookId)
        {
            return OrderDetailDAO.GetOrderDetailByOrderIdAndBookId(orderId, bookId);
        }

        public List<OrderDetail> GetOrderDetails()
        {
            return OrderDetailDAO.GetOrderDetails();
        }

        public void UpdateOrderDetail(OrderDetail od)
        {
            OrderDetailDAO.UpdateOrderDetail(od);
        }
    }
}
