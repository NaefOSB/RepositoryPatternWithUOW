using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.EF.Data;
using System.Linq.Expressions;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> match, string[] includes = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                    query = query.Include(include);

            return query.SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match) =>
            _context.Set<T>().Where(match).ToList();

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (string include in includes)
                query = query.Include(include);

            return query.Where(match).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes, int skip, int take)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                    query = query.Include(include);

            return query.Where(match).Skip(skip).Take(take).ToList();
        }
    }
}
