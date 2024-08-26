using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        string BookSpecialMethod();
    }
}
