using BusinessObject.Models;

namespace BookStoreClient.Models
{
    public class BookViewModel
    {
        public List<Book> Books { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public string Keywords { get; set; }
    }
}
