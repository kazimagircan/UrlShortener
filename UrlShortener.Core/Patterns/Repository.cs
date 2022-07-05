using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core.Patterns
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _urlShorterDBContext;
        private readonly DbSet<T> _db;
        public Repository(DbContext urlShorterDBContext)
        {
            _urlShorterDBContext = urlShorterDBContext;
            _db = _urlShorterDBContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async ValueTask<T> Find(Expression<Func<T, bool>> filter)
        {
            return await _db.FirstOrDefaultAsync(filter);
        }

        public int Save()
        {
            return _urlShorterDBContext.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return _db.Any(filter);
        }
    }
}
