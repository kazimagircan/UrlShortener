using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Core.Patterns
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
    }
}
