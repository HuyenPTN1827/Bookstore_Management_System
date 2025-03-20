using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISubCategoryRepository
    {
        List<SubCategory> GetSubCategories();
        List<SubCategory> FindSubCategoryByCategoryId(int categoryId);
        SubCategory FindSubCategoryById(int id);
        void AddSubCategory(SubCategory sc);
        void UpdateSubCategory(SubCategory sc);
        void DeleteSubCategory(SubCategory sc);
    }
}
