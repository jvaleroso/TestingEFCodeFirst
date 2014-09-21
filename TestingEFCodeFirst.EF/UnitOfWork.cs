using System;
using System.Collections.Concurrent;

namespace TestingEFCodeFirst.EF
{
    public class UnitOfWork<T> : IUnityOfWork<T> where T:class
    {
        private readonly CustomerDbContext _customerDbContext;

        private readonly ConcurrentDictionary<string, IGenericRepository<T>> _repositories =
            new ConcurrentDictionary<string, IGenericRepository<T>>();

        public UnitOfWork(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public IGenericRepository<T> Repository 
        {
            get
            {
                IGenericRepository<T> repo;
                if (_repositories.TryGetValue(typeof (T).ToString(), out repo)) return repo;

                repo = new GenericRepository<T>(_customerDbContext);
                _repositories.TryAdd(typeof(T).ToString(), repo);

                return repo;
            }
        }


        public void Save()
        {
            _customerDbContext.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _customerDbContext.Dispose();
            }
            _disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
