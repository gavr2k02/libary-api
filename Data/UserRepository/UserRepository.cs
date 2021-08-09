using Microsoft.Extensions.Logging;
using APILibary.Models;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace APILibary.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger _logger;
        private readonly LibaryContext _libaryContext;

        public UserRepository(LibaryContext libaryContext, ILogger<UserRepository> logger)
        {
            this._libaryContext = libaryContext;
            this._logger = logger;
        }

        public async Task addUser(User user)
        {
            this._libaryContext.Users.Add(user);
            await this._libaryContext.SaveChangesAsync();
            return;
        }

        public User getUser(User user)
        {
            return this._libaryContext.Users.First(item => item.Login == user.Login);
        }
    }
}