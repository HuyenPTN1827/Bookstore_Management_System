using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImpRep
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(Category c)
        {
            CategoryDAO.AddCategory(c);
        }

        public void DeleteCategory(Category c)
        {
            CategoryDAO.DeleteCategory(c);
        }

        public Category FindCategoryById(int id)
        {
            return CategoryDAO.FindCategoryById(id);
        }

        public List<Category> GetCategories()
        {
            return CategoryDAO.GetCategories();
        }

        public void UpdateCategory(Category c)
        {
            CategoryDAO.UpdateCategory(c);
        }
    }
}
