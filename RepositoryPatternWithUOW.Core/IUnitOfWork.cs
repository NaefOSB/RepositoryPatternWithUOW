using RepositoryPatternWithUOW.Core.Interfaces;

namespace RepositoryPatternWithUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        public IAuthorsRepository Authors { get; }
        public IBooksRepository Books { get; }

        int Complete();
    }
}
