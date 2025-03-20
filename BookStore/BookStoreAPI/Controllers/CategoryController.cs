using Microsoft.AspNetCore.Mvc;
using Repository.ImpRep;
using Repository;
using BusinessObject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _repository = new CategoryRepository();

        // GET: api/<CategoryController>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            return _repository.GetCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            return _repository.FindCategoryById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult AddCategory(Category category) { 
            _repository.AddCategory(category);
            return NoContent();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category category)
        {
            var c = _repository.FindCategoryById(id);
            if (c == null)
            {
                return NotFound();
            }
            c.CategoryName = category.CategoryName;

            _repository.UpdateCategory(c);
            return NoContent(); 
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var c = _repository.FindCategoryById(id);
            if (c == null)
            {
                return NotFound();
            }
            _repository.DeleteCategory(c);
            return NoContent();
        }
    }
}
