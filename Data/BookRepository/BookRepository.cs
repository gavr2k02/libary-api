using Microsoft.Extensions.Logging;
using APILibary.Models;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace APILibary.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly ILogger _logger;
        private readonly LibaryContext _libaryContext;

        public BookRepository(LibaryContext libaryContext, ILogger<BookRepository> logger)
        {
            this._libaryContext = libaryContext;
            this._logger = logger;
        }

        public async Task addBook(Book book)
        {
            this._libaryContext.Books.Add(book);
            await this._libaryContext.SaveChangesAsync();
            return;
        }

        public async Task deleteBook(int[] ids)
        {
            this._libaryContext.Books.RemoveRange(
                this._libaryContext.Books.Where(book => ids.Contains(book.Id))
            );
            await this._libaryContext.SaveChangesAsync();
            return;
        }

        public Book[] getBooks()
        {
            return this._libaryContext.Books.ToArray();
        }

        public async Task updateBook(Book book)
        {
            this._libaryContext.Books.Update(book);
            await this._libaryContext.SaveChangesAsync();
            return;
        }
    }
}