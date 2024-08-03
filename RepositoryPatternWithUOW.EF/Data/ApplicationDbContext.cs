using Microsoft.EntityFrameworkCore;

namespace RepositoryPatternWithUOW.EF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
