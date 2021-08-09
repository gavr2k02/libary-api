using System.Threading.Tasks;
using APILibary.Models;

namespace APILibary.Data
{
    public interface IBookRepository
    {
        Book[] getBooks();
        Task addBook(Book book);
        Task updateBook(Book book);
        Task deleteBook(int[] ids);
    }
}