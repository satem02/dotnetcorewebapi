using System;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Interfaces
{
 public interface IRepository<T> where T : class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        IQueryable<T> All();
        IQueryable<T> Where(Expression<Func<T, bool>> where);
        IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);
    }
}