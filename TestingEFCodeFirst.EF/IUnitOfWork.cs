
namespace TestingEFCodeFirst.EF
{
    public interface IUnityOfWork<T> where T : class
    {
        IRepository<T> Repository { get; }
        void Save();
    }
}
