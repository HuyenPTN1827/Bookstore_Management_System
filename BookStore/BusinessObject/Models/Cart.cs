using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int AccountId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }
}
