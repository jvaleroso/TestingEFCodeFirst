﻿using System.Collections.Generic;

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
