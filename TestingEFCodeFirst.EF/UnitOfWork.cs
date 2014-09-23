using System.Collections.Concurrent;

namespace TestingEFCodeFirst.EF
{
    public class UnitOfWork<T> : IUnityOfWork<T> where T : class
    {
        private readonly CustomerDbContext _customerDbContext;
        private readonly IRepository<T> _repo;

        private readonly ConcurrentDictionary<string, IRepository<T>> _repositories =
            new ConcurrentDictionary<string, IRepository<T>>();

        public UnitOfWork(CustomerDbContext customerDbContext, IRepository<T> repo)
        {
            _customerDbContext = customerDbContext;
            _repo = repo;
        }

        public IRepository<T> Repository
        {
            get
            {
                IRepository<T> repo;
                if (_repositories.TryGetValue(typeof(T).ToString(), out repo)) return repo;

                _repo.SetDbContext(_customerDbContext);
                _repositories.TryAdd(typeof(T).ToString(), _repo);

                return _repo;
            }
        }

        public void Save()
        {
            _customerDbContext.SaveChanges();
        }
    }
}
