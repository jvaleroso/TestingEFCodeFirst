using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestingEFCodeFirst.EF
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetList();
        Task<TEntity> Find(int id);
        void Insert(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        void SetDbContext(CustomerDbContext customerDbContext);
    }
}
