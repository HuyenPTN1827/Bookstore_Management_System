using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEventRepository
    {
        List<Event> GetEvents();
        List<int> GetActiveEventIds();
        Event FindEventById(int id);
        void AddEvent(Event r);
        void UpdateEvent(Event r);
        void DeleteEvent(Event r);
    }
}
