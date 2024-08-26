using RepositoryPatternWithUOW.Core.Models;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IAuthorsRepository : IBaseRepository<Author>
    {
        string AuthorSpecialMethod();
    }
}
