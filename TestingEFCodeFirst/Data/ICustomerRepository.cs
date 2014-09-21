using System;
using System.Collections.Generic;

namespace TestingEFCodeFirst.Data
{
    public interface ICustomerRepository : IDisposable
    {
        IList<Customer> GetList();
        void Save(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Customer Find(int id);
    }
}
