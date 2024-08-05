using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.EF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
