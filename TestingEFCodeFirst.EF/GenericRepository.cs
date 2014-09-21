using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestingEFCodeFirst.EF
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly CustomerDbContext _customerDbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
            _dbSet = customerDbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetList()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_customerDbContext.Entry(entityToDelete).State == EntityState.Detached)
                _dbSet.Attach(entityToDelete);

            _dbSet.Remove(entityToDelete);

        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _customerDbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
