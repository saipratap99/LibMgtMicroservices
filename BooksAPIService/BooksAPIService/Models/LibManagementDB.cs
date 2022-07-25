using Microsoft.EntityFrameworkCore;

namespace BooksAPIService.Models
{
    public class LibManagementDB : DbContext
    {
        public LibManagementDB(DbContextOptions<LibManagementDB> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookTag> BookTags { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().ToTable(nameof(Tags), t => t.ExcludeFromMigrations());

        }

    }

}
