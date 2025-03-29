using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Book
    {
        public Book()
        {
            BookDiscounts = new HashSet<BookDiscount>();
            Carts = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [JsonIgnore]
        public int BookId { get; set; }
        public string BookName { get; set; } = null!;
        public string? Cover { get; set; }
        public string Author { get; set; } = null!;
        public decimal Price { get; set; }
        [NotMapped]
        public decimal? DiscountedPrice { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? PublisherId { get; set; }
        public int? SubCategoryId { get; set; }
        public DateTime CreatedDate { get; set; }

        [JsonIgnore]
        public virtual Publisher? Publisher { get; set; }
        [JsonIgnore]
        public virtual SubCategory? SubCategory { get; set; }
        [JsonIgnore]
        public virtual ICollection<BookDiscount> BookDiscounts { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cart> Carts { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
