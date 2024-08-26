using System.Linq.Expressions;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Find(Expression<Func<T, bool>> criteria);
        T Find(Expression<Func<T, bool>> criteria, string[] includes);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes, int skip, int take);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes, int? skip, int? take, Expression<Func<T, object>> orderBy, string orderDirection);

        int Count();
        int Count(Expression<Func<T, bool>> criteria);

        T Add(T item);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Update(T item);
        void Delete(int id);
    }
}
