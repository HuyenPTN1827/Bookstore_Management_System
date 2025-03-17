using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDAO
    {
        public static List<Book> GetBooks()
        {
            var listBooks = new List<Book>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    listBooks = context.Books
                        .Include(x => x.Publisher)
                        .Include(x => x.SubCategory)
                        .OrderByDescending(x => x.BookId)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listBooks;
        }

        public static List<Book> SearchBooks(string keyword)
        {
            var listBooks = new List<Book>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    listBooks = context.Books
                        .Include(x => x.Publisher)
                        .Include(x => x.SubCategory)
                        .Where(x => x.BookName.ToLower().Trim().Contains(keyword.ToLower().Trim())
                        || x.Author.ToLower().Trim().Contains(keyword.ToLower().Trim())
                        || x.Publisher.PublisherName.ToLower().Trim().Contains(keyword.ToLower().Trim()))
                        .OrderByDescending(x => x.BookId)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listBooks;
        }

        public static List<Book> FindAllBooksBySubCategoryId(int subCategoryId)
        {
            var listBooks = new List<Book>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    listBooks = context.Books
                        .Include(x => x.Publisher)
                        .Include(x => x.SubCategory)
                        .Where(x => x.SubCategoryId == subCategoryId)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listBooks;
        }



        public static Book FindBookById(int bookId)
        {
            var book = new Book();
            try
            {
                using (var context = new BookStoreContext())
                {
                    book = context.Books
                        .Include(x => x.Publisher)
                        .Include(x => x.SubCategory)
                        .SingleOrDefault(x => x.BookId == bookId);
                    //if (book != null)
                    //{
                    //    book.OrderDetails = context.OrderDetails
                    //        .Include(x => x.Book)
                    //        .Include(x => x.Order)
                    //        .Where(x => x.BookId == bookId).ToList();
                    //}
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return book;
        }

        public static void AddBook(Book book)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Books.Add(book);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateProduct(Book book)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    context.Entry<Book>(book).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteBook(Book book)
        {
            try
            {
                using (var context = new BookStoreContext())
                {
                    var temp = context.Books
                        .SingleOrDefault(x => x.BookId == book.BookId);
                    context.Books.Remove(temp);
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
