using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImpRep
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        public void AddSubCategory(SubCategory sc)
        {
            SubCategoryDAO.AddSubCategory(sc);
        }

        public void DeleteSubCategory(SubCategory sc)
        {
            SubCategoryDAO.DeleteSubCategory(sc);
        }

        public List<SubCategory> FindSubCategoryByCategoryId(int categoryId)
        {
            return SubCategoryDAO.FindAllSubCategoriesByCategoryId(categoryId);
        }

        public SubCategory FindSubCategoryById(int id)
        {
            return SubCategoryDAO.FindSubCategoryById(id);
        }

        public List<SubCategory> GetCategories()
        {
            return SubCategoryDAO.GetSubCategories();
        }

        public void UpdateSubCategory(SubCategory sc)
        {
            SubCategoryDAO.UpdateSubCategory(sc);
        }
    }
}
