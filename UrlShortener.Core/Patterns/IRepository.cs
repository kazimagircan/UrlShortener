using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core.Patterns
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        bool Any(Expression<Func<T, bool>> filter);
        ValueTask<T> Find(Expression<Func<T, bool>> filter);
        int Save();
    }
}
