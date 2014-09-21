using System.Data.Entity;

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
