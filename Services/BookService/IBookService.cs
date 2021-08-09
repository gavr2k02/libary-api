using System.Threading.Tasks;
using APILibary.Models;

namespace APILibary.Services
{
    public interface IBookService
    {
        Book[] getBooks();
        Task addBook(Book book);
        Task updateBook(Book book);
        Task deleteBook(int[] id);
    }
}