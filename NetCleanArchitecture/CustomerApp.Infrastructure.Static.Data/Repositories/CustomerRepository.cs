using System;
using System.Collections.Generic;
using System.Text;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.Static.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private int id = 1;
        private List<Customer> _customers = new List<Customer>();    

        public Customer Create(Customer customer)
        {
            customer.Id = id++;
            _customers.Add(customer);
            return customer;

        }
       
        public IEnumerable<Customer> ReadAll()
        {
            return _customers;
        }

        public Customer ReadById(int id)
        {
            foreach (var customer in _customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }


        /// <summary>
        /// Remove later when we use UOW
        /// </summary>
        /// <param name="customerUpdate"></param>
        /// <returns></returns>
        public Customer Update(Customer customerUpdate)
        {
            var customerFromDB = ReadById(customerUpdate.Id);

            if (customerFromDB == null) return null;

            customerFromDB.FirstName = customerUpdate.FirstName;
            customerFromDB.LastName = customerUpdate.LastName;
            customerFromDB.Address = customerUpdate.Address;

            return customerFromDB;

        }

        public Customer Delete(int id)
        {
            var customerFound = ReadById(id);
            if (customerFound == null) return null;

            _customers.Remove(customerFound);
            return customerFound;
        }
    }
}
