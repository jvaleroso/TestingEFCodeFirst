using System.Collections.Generic;
using TestingEFCodeFirst.Data;

namespace TestingEFCodeFirst.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerDao _customerDao;

        public CustomerService(ICustomerDao customerDao)
        {
            _customerDao = customerDao;
        }

        public IList<Customer> GetList()
        {
            return _customerDao.GetList();
        }

        public void Save(Customer customer)
        {
            _customerDao.Save(customer);
        }

        public void Update(Customer customer)
        {
            _customerDao.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDao.Delete(customer);
        }

        public Customer Find(int id)
        {
            return _customerDao.Find(id);
        }
    }
}
