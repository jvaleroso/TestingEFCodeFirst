using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace TestingEFCodeFirst.EF
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private CustomerDbContext _customerDbContext;
        private DbSet<TEntity> _dbSet;

        public void SetDbContext(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
            _dbSet = _customerDbContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetList()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> Find(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            var dbSet = _customerDbContext.Set<TEntity>();
            dbSet.Add(entity);
        }

        public virtual void Delete(int id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.AddOrUpdate(entityToUpdate);
        }
    }
}
