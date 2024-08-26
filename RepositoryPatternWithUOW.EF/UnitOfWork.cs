using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.EF.Data;
using RepositoryPatternWithUOW.EF.Repositories;

namespace RepositoryPatternWithUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IAuthorsRepository Authors { get; private set; }
        public IBooksRepository Books { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Authors = new AuthorsRepository(_context);
            Books = new BooksRepository(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
