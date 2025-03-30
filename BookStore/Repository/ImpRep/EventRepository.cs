using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImpRep
{
    public class EventRepository : IEventRepository
    {
        public void AddEvent(Event r)
        {
            EventDAO.AddEvent(r);
        }

        public void DeleteEvent(Event r)
        {
            EventDAO.DeleteEvent(r);
        }

        public Event FindEventById(int id)
        {
            return EventDAO.FindEventById(id);
        }

        public List<int> GetActiveEventIds()
        {
            return EventDAO.GetActiveEventIds();
        }

        public List<Event> GetEvents()
        {
            return EventDAO.GetEvents();
        }

        public void UpdateEvent(Event r)
        {
            EventDAO.UpdateEvent(r);
        }
    }
}
