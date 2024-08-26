using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.General.Constants;
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
        public T Find(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().FirstOrDefault(criteria);
        }
        public T Find(Expression<Func<T, bool>> criteria, string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                    query = query.Include(include);

            return query.FirstOrDefault(criteria);
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria) =>
            _context.Set<T>().Where(criteria).ToList();
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes)
        {
            var query = _context.Set<T>().Where(criteria);

            if (includes != null)
                foreach (string include in includes)
                    query = query.Include(include);

            return query.ToList();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes, int skip, int take)
        {
            var query = _context.Set<T>().Where(criteria);

            if (includes != null)
                foreach (string include in includes)
                    query = query.Include(include);

            return query.Skip(skip).Take(take).ToList();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes, int? skip, int? take, Expression<Func<T, object>> orderBy, string orderDirection)
        {
            var query = _context.Set<T>().Where(criteria);

            if (includes != null)
                foreach (string include in includes)
                    query = query.Include(include);

            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderDirection == OrderBy.Ascending)
                query = query.OrderBy(orderBy);
            else if (orderDirection == OrderBy.Descending)
                query = query.OrderByDescending(orderBy);

            return query.ToList();
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }
        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Count(criteria);
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }
        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
        public void Delete(int id)
        {
            T entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
        }
    }
}
