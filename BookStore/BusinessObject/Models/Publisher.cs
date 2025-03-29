using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        [JsonIgnore]
        public int PublisherId { get; set; }
        public string PublisherName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}
