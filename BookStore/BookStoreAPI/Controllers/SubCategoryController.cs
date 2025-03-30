using Microsoft.AspNetCore.Mvc;
using Repository.ImpRep;
using Repository;
using BusinessObject.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private ISubCategoryRepository _repository = new SubCategoryRepository();

        // GET: api/<SubCategoryController>
        [HttpGet]
        public ActionResult<IEnumerable<SubCategory>> GetSubCategories()
        {
            return _repository.GetSubCategories();
        }

        [HttpGet("GetSubCategoriesByCategoryId/{categoryId}")]
        public ActionResult<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int categoryId)
        {
            return _repository.FindSubCategoryByCategoryId(categoryId);
        }

        // GET api/<SubCategoryController>/5
        [HttpGet("{id}")]
        public ActionResult<SubCategory> GetSubCategoryById(int id) 
        {
            return _repository.FindSubCategoryById(id);
        }

        // POST api/<SubCategoryController>
        [HttpPost]
        public IActionResult AddSubCategory(SubCategory subCategory)
        {
            _repository.AddSubCategory(subCategory);
            return NoContent();
        }

        // PUT api/<SubCategoryController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateSubCategory(int id, SubCategory subCategory)
        {
            var sc = _repository.FindSubCategoryById(id);
            if (sc == null)
            {
                return NotFound();
            }

            sc.SubCategoryName = subCategory.SubCategoryName;
            sc.CategoryId = subCategory.CategoryId;

            _repository.UpdateSubCategory(sc);
            return NoContent();
        }

        // DELETE api/<SubCategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubCategory(int id)
        {
            var sc = _repository.FindSubCategoryById(id);
            if (sc == null)
            {
                return NotFound();
            }
            _repository.DeleteSubCategory(sc);
            return NoContent();
        }
    }
}
