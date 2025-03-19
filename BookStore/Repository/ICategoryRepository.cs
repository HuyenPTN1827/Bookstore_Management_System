using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category FindCategoryById(int id);
        void AddCategory(Category c);
        void UpdateCategory(Category c);
        void DeleteCategory(Category c);
    }
}
