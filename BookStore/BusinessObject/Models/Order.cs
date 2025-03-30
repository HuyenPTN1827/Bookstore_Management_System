using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [JsonIgnore]
        public int OrderId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? AccountId { get; set; }
        public decimal? TotalAmount { get; set; }

        [JsonIgnore]
        public virtual Account? Account { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
