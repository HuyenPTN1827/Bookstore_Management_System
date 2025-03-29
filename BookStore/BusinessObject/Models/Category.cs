using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        [JsonIgnore]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
