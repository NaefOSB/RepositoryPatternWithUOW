using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF.Data;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorsRepository
    {
        public AuthorsRepository(ApplicationDbContext context) : base(context) { }
        public string AuthorSpecialMethod()
        {
            return "Author Special Method";
        }
    }
}
