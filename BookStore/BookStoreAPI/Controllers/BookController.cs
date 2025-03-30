using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.ImpRep;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository _repository = new BookRepository();

        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _repository.GetBooks();
        }

        [HttpGet("Search/{keyword}")]
        public ActionResult<IEnumerable<Book>> SearchBook(string keyword)
        {
            return _repository.SearchBook(keyword);
        }

        [HttpGet("GetBySubCategoryId/{subCategoryId}")]
        public ActionResult<IEnumerable<Book>> GetBySubCategoryId(int subCategoryId)
        {
            return _repository.FindBookBySubCategoryId(subCategoryId);
        }

        [HttpGet("GetByCategoryId/{categoryId}")]
        public ActionResult<IEnumerable<Book>> GetByCategoryId(int categoryId)
        {
            return _repository.FindBookByCategoryId(categoryId);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            return _repository.FindBookById(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            var b = new Book()
            {
                BookName = book.BookName,
                Cover = book.Cover,
                Author = book.Author,
                Price = book.Price,
                Description = book.Description,
                Quantity = book.Quantity,
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                PublisherId = book.PublisherId,
                SubCategoryId = book.SubCategoryId
            };
            _repository.AddBook(b);
            return NoContent();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            var b = _repository.FindBookById(id);
            if (b == null)
            {
                return NotFound();
            }

            b.BookName = book.BookName;
            b.Cover = book.Cover;
            b.Author = book.Author;
            b.Price = book.Price;
            b.Description = book.Description;
            b.Quantity = book.Quantity;
            b.UpdatedDate = DateTime.Now;
            b.PublisherId = book.PublisherId;
            b.SubCategoryId = book.SubCategoryId;

            _repository.UpdateBook(b);
            return NoContent();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var b = _repository.FindBookById(id);
            if (b == null)
            {
                return NotFound();
            }

            _repository.DeleteBook(b);
            return NoContent();
        }
    }
}
