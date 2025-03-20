using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class BookRequest
    {
        public BookRequest()
        {
        }

        public string BookName { get; set; } = null!;
        public string? Cover { get; set; }
        public string Author { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int PublisherId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
