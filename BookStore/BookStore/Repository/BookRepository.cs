using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context) 
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel bookModel) 
        {
            var newBook = new Books()
            {
                Author = bookModel.Author,
                CreatedOn = DateTime.UtcNow,
                Description = bookModel.Description,
                Title = bookModel.Title,
                Pages = bookModel.Pages.HasValue ? bookModel.Pages.Value  : 0,
                UpdatedOn = DateTime.UtcNow
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;

        }
        public async Task<List<BookModel>> GetAllBooks() 
        {
            var books = new List<BookModel>();
            var data = await _context.Books.ToListAsync();
            if (data?.Any() == true)
            {
                foreach (var book in data)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Description = book.Description,
                        Pages = book.Pages,
                        Id = book.Id,
                        Category = book.Category,
                        Language = book.Language
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id) {
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    Pages = book.Pages,
                    Id = book.Id,
                    Category = book.Category,
                    Language = book.Language
                };
                return bookDetails;
            }
            return null;
        }
    }
}
