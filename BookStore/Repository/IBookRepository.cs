﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        List<Book> SearchBook(string keyword);
        List<Book> FindBookBySubCategoryId(int subCategoryId);
        List<Book> FindBookByCategoryId(int categoryId);
        Book FindBookById(int id);
        Book GetBookById(int id);
        void AddBook(Book b);
        void UpdateBook(Book b);
        void DeleteBook(Book b);
    }
}
