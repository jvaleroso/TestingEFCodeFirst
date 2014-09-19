using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestingEFCodeFirst.Data;

namespace TestingEFCodeFirst.EF.Dao
{
    public class CustomerDao : ICustomerDao
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerDao(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public IList<Customer> GetList()
        {
            return _customerDbContext.Customers.ToList();
        }

        public void Save(Customer customer)
        {
            _customerDbContext.Customers.Add(customer);
            _customerDbContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _customerDbContext.Entry(customer).State = EntityState.Modified;
            _customerDbContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _customerDbContext.Customers.Remove(customer);
            _customerDbContext.SaveChanges();
        }

        public Customer Find(int id)
        {
            return _customerDbContext.Customers.Find(id);
        }
    }
}
