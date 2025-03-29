using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        [JsonIgnore]
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
