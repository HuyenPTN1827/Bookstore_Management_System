using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class EventDiscount
    {
        public int DiscountId { get; set; }
        public int EventId { get; set; }
        public int MinQuantity { get; set; }
        public int? MaxQuantity { get; set; }
        public decimal DiscountPercent { get; set; }

        public virtual Event Event { get; set; } = null!;
    }
}
