using Microsoft.EntityFrameworkCore;

namespace UsersAPIService.Models
{
    public class LibManagementDB: DbContext
    {

        public LibManagementDB(DbContextOptions<LibManagementDB> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTag> UserTags { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().ToTable(nameof(Tags), t => t.ExcludeFromMigrations());
        }

    }
}
