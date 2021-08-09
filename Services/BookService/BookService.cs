using Microsoft.Extensions.Logging;
using APILibary.Data;
using APILibary.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace APILibary.Services
{
    public class BookService : IBookService
    {
        private readonly ILogger _logger;
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            this._bookRepository = bookRepository;
            this._logger = logger;
        }

        [Authorize]
        public Task addBook(Book book)
        {
            return this._bookRepository.addBook(book);
        }

        [Authorize]
        public Task deleteBook(int[] ids)
        {
            return this._bookRepository.deleteBook(ids);
        }

        [Authorize]
        public Book[] getBooks()
        {
            return this._bookRepository.getBooks();
        }

        [Authorize]
        public Task updateBook(Book book)
        {
            return this._bookRepository.updateBook(book);
        }
    }
}