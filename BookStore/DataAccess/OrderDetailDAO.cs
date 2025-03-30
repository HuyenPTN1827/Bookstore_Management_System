using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        public static List<OrderDetail> GetOrderDetails()
        {
            var orderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    orderDetails = context.OrderDetails
                        .Include(x => x.Order)
                        .Include(x => x.Book)
                        .ThenInclude(x => x.BookDiscounts)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public static List<OrderDetail> GetOrderDetailsByBookId(int bookId)
        {
            var orderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    orderDetails = context.OrderDetails
                        .Include(x => x.Order)
                        .Include(x => x.Book)
                        .ThenInclude(x => x.BookDiscounts)
                        .Where(x => x.BookId == bookId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public static List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    orderDetails = context.OrderDetails
                        .Include(x => x.Order)
                        .Include(x => x.Book)
                        .ThenInclude(x => x.BookDiscounts)
                        .Where(x => x.OrderId == orderId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public static OrderDetail GetOrderDetailByOrderIdAndBookId(int orderId, int bookId)
        {
            var orderDetail = new OrderDetail();
            try
            {
                using (var context = new BookStoreContext())
                {
                    orderDetail = context.OrderDetails
                        .Include(x => x.Order)
                        .Include(x => x.Book)
                        .ThenInclude(x => x.BookDiscounts)
                        .SingleOrDefault(x => x.OrderId == orderId && x.BookId == bookId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public static void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Entry<OrderDetail>(orderDetail).State = 
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    var temp = context.OrderDetails
                        .SingleOrDefault(x => x.OrderId == orderDetail.OrderId
                        && x.BookId == orderDetail.BookId);
                    context.OrderDetails.Remove(temp);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
