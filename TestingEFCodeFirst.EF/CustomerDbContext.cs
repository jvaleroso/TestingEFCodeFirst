using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingEFCodeFirst.EF
{
    public class CustomerDbContext: DbContext
    {
        public CustomerDbContext() : base("customer-db")
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
