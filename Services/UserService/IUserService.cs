using System.Threading.Tasks;
using APILibary.Models;

namespace APILibary.Services
{
    public interface IUserService
    {
        Task<string> addUser(User user);
        string signInWithPassword(User user);
    }
}