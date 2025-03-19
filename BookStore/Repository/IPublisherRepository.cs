using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPublisherRepository
    {
        List<Publisher> GetPublishers();
        Publisher FindPublisherById(int id);
        void AddPublisher(Publisher p);
        void UpdatePublisher(Publisher p);
        void DeletePublisher(Publisher p);
    }
}
