using System.Linq.Expressions;

namespace RepositoryPatternWithUOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        T Find(Expression<Func<T, bool>> match, string[] includes = null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> match);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes, int skip, int take);
    }
}
