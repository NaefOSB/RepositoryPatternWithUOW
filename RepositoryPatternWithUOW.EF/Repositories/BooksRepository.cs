using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.EF.Data;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        public BooksRepository(ApplicationDbContext context) : base(context) { }
        public string BookSpecialMethod()
        {
            return "Book Special Method";
        }
    }
}
