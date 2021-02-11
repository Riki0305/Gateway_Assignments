using CustomerApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Services
{
    public class CustomerService
    {
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            for (int i = 1; i <= 3; i++)
            {
                customers.Add(new Customer
                {
                    Id = i,
                    Name = $"Customer{i}",
                    Address = $"Address_{i}",
                    Email = $"Email{i}",
                    Mobile = $"Mobile{i}"
                });
            }
            return customers;
        }
    }
}
