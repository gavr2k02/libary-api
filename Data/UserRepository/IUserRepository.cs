using System.Threading.Tasks;
using APILibary.Models;

namespace APILibary.Data
{
    public interface IUserRepository
    {
        User getUser(User user);
        Task addUser(User user);
    }
}