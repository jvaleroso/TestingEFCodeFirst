using System;

namespace TestingEFCodeFirst
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }
}
