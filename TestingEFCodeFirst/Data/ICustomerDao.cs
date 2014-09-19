using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingEFCodeFirst.Data
{
    public interface ICustomerDao
    {
        IList<Customer> GetList();
        void Save(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Customer Find(int id);
    }
}
