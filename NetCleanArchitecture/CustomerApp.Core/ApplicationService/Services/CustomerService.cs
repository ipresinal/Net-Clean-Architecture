using System;
using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerRepository _customerRepo;
        readonly IOrderRepository _orderRepo;

        public CustomerService(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepo = customerRepository;
            _orderRepo = orderRepository;
        }

        public Customer NewCustomer(string firstName, string lastName, string address)
        {
            var cust = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            };
            return cust;
        }

        public Customer CreateCustomer(Customer cust)
        {
            return _customerRepo.Create(cust);
        }

        public Customer FindCustomerById(int id)
        {
            return _customerRepo.ReadById(id);
        }

        public Customer FindCustomerByIdIncludeOrders(int id)
        {
            var customer = _customerRepo.FindCustomerByIdIncludeOrders(id);
            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.ReadAll().ToList();
        }

        public List<Customer> GetAllByFirstName(string name)
        {

            var list = _customerRepo.ReadAll();
            // Not executed anything yet
            var queryContinued = list.Where(cust => cust.FirstName == name);
            queryContinued.OrderBy(customer => customer.FirstName);

            return queryContinued.ToList();
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            var customer = FindCustomerById(customerToUpdate.Id);
            customer.FirstName = customerToUpdate.FirstName;
            customer.LastName = customerToUpdate.LastName;
            customer.Address = customerToUpdate.Address;

            return customer;
        }

        public Customer DeleteCustomer(int id)
        {
            return _customerRepo.Delete(id);
        }

        
        
    }
}
