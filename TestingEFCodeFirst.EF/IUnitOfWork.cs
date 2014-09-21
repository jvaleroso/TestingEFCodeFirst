using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingEFCodeFirst.EF
{
    public interface IUnityOfWork<T> : IDisposable where T : class
    {
        IGenericRepository<T> Repository { get; }
        void Save();
    }
}
