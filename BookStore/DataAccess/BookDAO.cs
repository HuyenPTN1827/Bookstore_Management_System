using BusinessObject.DTO;
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
                    // Lấy danh sách ID sự kiện đang diễn ra
                    var activeEvents = context.Events
                        .Where(e => e.StartDate <= DateTime.Now && e.EndDate >= DateTime.Now)
                        .Select(e => e.EventId)
                        .ToList();

                    listBooks = context.Books
                        .Include(x => x.BookDiscounts)
                        .Select(x => new Book
                        {
                            BookId = x.BookId,
                            BookName = x.BookName,
                            Cover = x.Cover,
                            Author = x.Author,
                            Price = x.Price,
                            Description = x.Description,
                            Quantity = x.Quantity,
                            PublisherId = x.PublisherId,
                            SubCategoryId = x.SubCategoryId,
                            CreatedDate = x.CreatedDate,
                            UpdatedDate = x.UpdatedDate,

                            // Kiểm tra xem sách có khuyến mãi trong sự kiện đang diễn ra không
                            DiscountedPrice = x.BookDiscounts
                                .Where(d => activeEvents.Contains(d.EventId))
                                .Select(d => x.Price * (1 - d.DiscountPercent / 100))
                                .FirstOrDefault()  // Lấy khuyến mãi đầu tiên (nếu có)
                        })
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
                    var activeEvents = context.Events
                        .Where(e => e.StartDate <= DateTime.Now && e.EndDate >= DateTime.Now)
                        .Select(e => e.EventId)
                        .ToList();

                    listBooks = context.Books
                        .Include(x => x.BookDiscounts)
                        .Include(x => x.Publisher)
                        .Where(x => x.BookName.ToLower().Trim().Contains(keyword.ToLower().Trim())
                        || x.Author.ToLower().Trim().Contains(keyword.ToLower().Trim())
                        || x.Publisher.PublisherName.ToLower().Trim().Contains(keyword.ToLower().Trim()))
                        .Select(x => new Book
                        {
                            BookId = x.BookId,
                            BookName = x.BookName,
                            Cover = x.Cover,
                            Author = x.Author,
                            Price = x.Price,
                            Description = x.Description,
                            Quantity = x.Quantity,
                            PublisherId = x.PublisherId,
                            SubCategoryId = x.SubCategoryId,
                            CreatedDate = x.CreatedDate,
                            UpdatedDate = x.UpdatedDate,

                            DiscountedPrice = x.BookDiscounts
                                .Where(d => activeEvents.Contains(d.EventId))
                                .Select(d => x.Price * (1 - d.DiscountPercent / 100))
                                .FirstOrDefault()
                        })
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
                    var activeEvents = context.Events
                        .Where(e => e.StartDate <= DateTime.Now && e.EndDate >= DateTime.Now)
                        .Select(e => e.EventId)
                        .ToList();

                    listBooks = context.Books
                        .Include(x => x.BookDiscounts)
                        .Include(x => x.SubCategory)
                        .Where(x => x.SubCategoryId == subCategoryId)
                        .Select(x => new Book
                        {
                            BookId = x.BookId,
                            BookName = x.BookName,
                            Cover = x.Cover,
                            Author = x.Author,
                            Price = x.Price,
                            Description = x.Description,
                            Quantity = x.Quantity,
                            PublisherId = x.PublisherId,
                            SubCategoryId = x.SubCategoryId,
                            CreatedDate = x.CreatedDate,
                            UpdatedDate = x.UpdatedDate,

                            DiscountedPrice = x.BookDiscounts
                                .Where(d => activeEvents.Contains(d.EventId))
                                .Select(d => x.Price * (1 - d.DiscountPercent / 100))
                                .FirstOrDefault()
                        })
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

        public static List<Book> FindAllBooksByCategoryId(int categoryId)
        {
            var listBooks = new List<Book>();
            try
            {
                using (var context = new BookStoreContext())
                {
                    var activeEvents = context.Events
                        .Where(e => e.StartDate <= DateTime.Now && e.EndDate >= DateTime.Now)
                        .Select(e => e.EventId)
                        .ToList();

                    listBooks = context.Books
                        .Include(x => x.BookDiscounts)
                        .Include(x => x.SubCategory)
                        .ThenInclude(c => c.Category)
                        .Where(x => x.SubCategory.CategoryId == categoryId)
                        .Select(x => new Book
                        {
                            BookId = x.BookId,
                            BookName = x.BookName,
                            Cover = x.Cover,
                            Author = x.Author,
                            Price = x.Price,
                            Description = x.Description,
                            Quantity = x.Quantity,
                            PublisherId = x.PublisherId,
                            SubCategoryId = x.SubCategoryId,
                            CreatedDate = x.CreatedDate,
                            UpdatedDate = x.UpdatedDate,

                            DiscountedPrice = x.BookDiscounts
                                .Where(d => activeEvents.Contains(d.EventId))
                                .Select(d => x.Price * (1 - d.DiscountPercent / 100))
                                .FirstOrDefault()
                        })
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

        public static Book FindBookById(int bookId)
        {
            var book = new Book();
            try
            {
                using (var context = new BookStoreContext())
                {
                    var activeEvents = context.Events
                        .Where(e => e.StartDate <= DateTime.Now && e.EndDate >= DateTime.Now)
                        .Select(e => e.EventId)
                        .ToList();

                    book = context.Books
                        .Include(x => x.BookDiscounts)
                        .Include(x => x.Publisher)
                        .Include(x => x.SubCategory)
                        .ThenInclude(x => x.Category)
                        .Select(x => new Book
                        {
                            BookId = x.BookId,
                            BookName = x.BookName,
                            Cover = x.Cover,
                            Author = x.Author,
                            Price = x.Price,
                            Description = x.Description,
                            Quantity = x.Quantity,
                            PublisherId = x.PublisherId,
                            SubCategoryId = x.SubCategoryId,
                            CreatedDate = x.CreatedDate,
                            UpdatedDate = x.UpdatedDate,

                            DiscountedPrice = x.BookDiscounts
                                .Where(d => activeEvents.Contains(d.EventId))
                                .Select(d => x.Price * (1 - d.DiscountPercent / 100))
                                .FirstOrDefault(),

                            Publisher = x.Publisher,
                            SubCategory = x.SubCategory
                        })
                        .SingleOrDefault(x => x.BookId == bookId);
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
