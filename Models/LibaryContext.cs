using Microsoft.EntityFrameworkCore;

namespace APILibary.Models
{
    public class LibaryContext : DbContext
    {
        public LibaryContext(DbContextOptions<LibaryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}