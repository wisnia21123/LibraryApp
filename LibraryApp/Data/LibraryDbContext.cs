using LibraryApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Book => Set<Book>();

        public DbSet<Client> Client => Set<Client>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
