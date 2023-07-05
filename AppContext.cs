using Microsoft.EntityFrameworkCore;
using Module_25.DAL.Entities;

namespace Module_25
{
    public class AppContext : DbContext
    {
        //Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы Books
        public DbSet<Book> Books { get; set; }

        // Объекты таблицы BooksDescription
        public DbSet<BookDescription> BookDescriptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EF;Trusted_Connection=True;");
        }
    }
}
