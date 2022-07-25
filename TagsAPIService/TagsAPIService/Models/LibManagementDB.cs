using Microsoft.EntityFrameworkCore;

namespace TagsAPIService.Models
{
    public class LibManagementDB: DbContext
    {
        public LibManagementDB(DbContextOptions<LibManagementDB> options) : base(options)
        {

        }

        public DbSet<Tag> Tags { get; set; }
    }
}
