using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImpRep
{
    public class BookRepository : IBookRepository
    {
        public void AddBook(Book b)
        {
            BookDAO.AddBook(b);
        }

        public void DeleteBook(Book b)
        {
            BookDAO.DeleteBook(b);
        }

        public Book FindBookById(int id)
        {
            return BookDAO.FindBookById(id);
        }

        public List<Book> FindBookBySubCategoryId(int subCategoryId)
        {
            return BookDAO.FindAllBooksBySubCategoryId(subCategoryId);
        }

        public List<Book> GetBooks()
        {
            return BookDAO.GetBooks();
        }

        public List<Book> SearchBook(string keyword)
        {
            return BookDAO.SearchBooks(keyword);
        }

        public void UpdateBook(Book b)
        {
            BookDAO.UpdateProduct(b);
        }
    }
}
