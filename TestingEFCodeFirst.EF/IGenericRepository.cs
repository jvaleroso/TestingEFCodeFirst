using System.Collections.Generic;

namespace TestingEFCodeFirst.EF
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetList();
        TEntity Find(int id);
        void Insert(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}
