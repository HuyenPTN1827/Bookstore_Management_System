using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImpRep
{
    public class PublisherRepository : IPublisherRepository
    {
        public void AddPublisher(Publisher p)
        {
            PublisherDAO.AddPublisher(p);
        }

        public void DeletePublisher(Publisher p)
        {
            PublisherDAO.DeletePublisher(p);
        }

        public Publisher FindPublisherById(int id)
        {
            return PublisherDAO.FindPublisherById(id);
        }

        public List<Publisher> GetPublishers()
        {
            return PublisherDAO.GetPublishers();
        }

        public void UpdatePublisher(Publisher p)
        {
            PublisherDAO.UpdatePublisher(p);
        }
    }
}
