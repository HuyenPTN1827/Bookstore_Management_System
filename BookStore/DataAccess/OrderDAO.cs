using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        public static List<Order> GetOrders()
        {
            var orders = new List<Order>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    orders = context.Orders.Include(x => x.Account).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public static List<Order> GetOrdersByAccountId(int accountId)
        {
            var orders = new List<Order>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    orders = context.Orders
                        .Where(x => x.AccountId == accountId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public static Order GetOrderById(int id)
        {
            var order = new Order();
            try
            {
                using (var context = new BookStoreContext())
                {
                    order = context.Orders
                        .Include(x => x.Account)
                        .SingleOrDefault(o => o.OrderId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public static Order AddOrder(Order order)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public static void UpdateOrder(Order order)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Entry<Order>(order).State = 
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteOrder(Order order)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    var temp = context.Orders
                        .SingleOrDefault(x => x.OrderId == order.OrderId);
                    context.Orders.Remove(temp);
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
