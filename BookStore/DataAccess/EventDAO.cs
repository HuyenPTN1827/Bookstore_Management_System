using BusinessObject.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EventDAO
    {
        public static List<Event> GetEvents()
        {
            var listEvents = new List<Event>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    listEvents = context.Events.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listEvents;
        }

        public static List<int> GetActiveEventIds()
        {
            var activeEventIds = new List<int>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    activeEventIds = context.Events
                        .Where(e => e.StartDate <= DateTime.Now && e.EndDate >= DateTime.Now)
                        .Select(e => e.EventId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return activeEventIds;
        }

        public static Event FindEventById(int eventId)
        {
            var Event = new Event();
            try
            {
                using (var context = new BookStoreContext())
                {
                    Event = context.Events.SingleOrDefault(x => x.EventId == eventId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Event;
        }

        public static void AddEvent(Event role)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Events.Add(role);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateEvent(Event role)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Entry<Event>(role).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteEvent(Event role)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    var temp = context.Events
                        .SingleOrDefault(x => x.EventId == role.EventId);
                    context.Events.Remove(temp);
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
