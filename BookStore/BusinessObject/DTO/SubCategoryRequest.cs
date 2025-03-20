using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class SubCategoryRequest
    {
        public SubCategoryRequest()
        {
        }

        public string SubCategoryName { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
