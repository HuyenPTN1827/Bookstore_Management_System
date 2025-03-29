using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Event
    {
        public Event()
        {
            BookDiscounts = new HashSet<BookDiscount>();
            EventDiscounts = new HashSet<EventDiscount>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<BookDiscount> BookDiscounts { get; set; }
        public virtual ICollection<EventDiscount> EventDiscounts { get; set; }
    }
}
