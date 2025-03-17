using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SubCategoryDAO
    {
        public static List<SubCategory> GetSubCategories()
        {
            var listSubCategories = new List<SubCategory>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    listSubCategories = context.SubCategories
                        .Include(x => x.Category)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listSubCategories;
        }

        public static List<SubCategory> FindAllSubCategoriesByCategoryId(int categoryId)
        {
            var listSubCategories = new List<SubCategory>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    listSubCategories = context.SubCategories
                        .Include(x => x.Category)
                        .Where(x => x.CategoryId == categoryId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listSubCategories;
        }

        public static SubCategory FindSubCategoryById(int subCategoryID)
        {
            var subCategory = new SubCategory();
            try
            {
                using (var context = new BookStoreContext())
                {
                    subCategory = context.SubCategories
                        .Include(x => x.Category)
                        .SingleOrDefault(x => x.CategoryId == subCategoryID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return subCategory;
        }

        public static void AddSubCategory(SubCategory subCategory)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.SubCategories.Add(subCategory);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateSubCategory(SubCategory subCategory)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Entry<SubCategory>(subCategory).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCategory(SubCategory subCategory)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    var temp = context.SubCategories
                        .SingleOrDefault(x => x.CategoryId == subCategory.CategoryId);
                    context.SubCategories.Remove(temp);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
