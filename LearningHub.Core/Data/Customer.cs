using System;
using System.Collections.Generic;

namespace LearningHub.Core.Data
{
    public partial class Customer
    {
        public Customer()
        {
            ProductCustomers = new HashSet<ProductCustomer>();
            UserLogins = new HashSet<UserLogin>();
        }

        public decimal Idcos { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? ImagePath { get; set; }

        public virtual ICollection<ProductCustomer> ProductCustomers { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
