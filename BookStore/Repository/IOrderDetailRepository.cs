using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetOrderDetails();
        List<OrderDetail> GetOrderDetailByBookId(int bookId);
        List<OrderDetail> GetOrderDetailByOrderId(int orderId);
        OrderDetail GetOrderDetailByOrderIdAndBookId(int orderId, int bookId);
        void AddOrderDetail(OrderDetail od);
        void UpdateOrderDetail(OrderDetail od);
        void DeleteOrderDetail(OrderDetail od);
    }
}
