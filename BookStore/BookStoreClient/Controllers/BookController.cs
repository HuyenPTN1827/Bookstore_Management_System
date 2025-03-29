using BookStoreClient.Models;
using BookStoreClient.Utils;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace BookStoreClient.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient client = null;
        private string BookApiUrl = "";
        private string CategoryApiUrl = "";
        private string SubCategoryApiUrl = "";

        public BookController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BookApiUrl = "https://localhost:7149/api/Book";
            CategoryApiUrl = "https://localhost:7149/api/Category";
            SubCategoryApiUrl = "https://localhost:7149/api/SubCategory";

        }

        [HttpGet]
        public async Task<IActionResult> Index(string keyword = "")
        {
            List<Book> books = await ApiHandler.DeserializeApiResponse<List<Book>>(BookApiUrl, HttpMethod.Get);
            List<Category> categories = await ApiHandler.DeserializeApiResponse<List<Category>>(CategoryApiUrl, HttpMethod.Get);
            List<SubCategory> subCategories = await ApiHandler.DeserializeApiResponse<List<SubCategory>>(SubCategoryApiUrl, HttpMethod.Get);

            var model = new BookViewModel
            {
                Books = books,
                Categories = categories,
                Keywords = keyword
            };

            return View(model);
        }

        [HttpGet("GetSubCategoriesByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetSubCategoriesByCategoryId(int categoryId)
        {
            List<SubCategory> subCategories = await ApiHandler.DeserializeApiResponse<List<SubCategory>>(
                $"{SubCategoryApiUrl}/GetSubCategoriesByCategoryId/{categoryId}", HttpMethod.Get);

            return Json(subCategories);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
