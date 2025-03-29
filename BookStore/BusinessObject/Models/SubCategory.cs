using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Books = new HashSet<Book>();
        }

        [JsonIgnore]
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category? Category { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}
