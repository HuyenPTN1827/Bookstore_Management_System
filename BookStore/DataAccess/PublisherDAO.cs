using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PublisherDAO
    {
        public static List<Publisher> GetPublishers()
        {
            var listPublishers = new List<Publisher>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    listPublishers = context.Publishers.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listPublishers;
        }

        public static Publisher FindPublisherById(int publisherId)
        {
            var publisher = new Publisher();
            try
            {
                using (var context = new BookStoreContext())
                {
                    publisher = context.Publishers.SingleOrDefault(x => x.PushlisherId == publisherId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return publisher;
        }

        public static void AddPublisher(Publisher publisher)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Publishers.Add(publisher);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdatePublisher(Publisher publisher)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Entry<Publisher>(publisher).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeletePublisher(Publisher publisher)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    var temp = context.Publishers
                        .SingleOrDefault(x => x.PushlisherId == publisher.PushlisherId);
                    context.Publishers.Remove(temp);
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
