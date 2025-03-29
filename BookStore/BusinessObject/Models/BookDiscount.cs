using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class BookDiscount
    {
        public int BookDiscountId { get; set; }
        public int EventId { get; set; }
        public int BookId { get; set; }
        public decimal DiscountPercent { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Event Event { get; set; } = null!;
    }
}
