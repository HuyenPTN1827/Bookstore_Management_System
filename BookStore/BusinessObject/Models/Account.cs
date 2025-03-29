using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Account
    {
        public Account()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        [JsonIgnore]
        public int AccountId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Fullname { get; set; }
        public string Email { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? RoleId { get; set; }

        [JsonIgnore]
        public virtual Role? Role { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cart> Carts { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
