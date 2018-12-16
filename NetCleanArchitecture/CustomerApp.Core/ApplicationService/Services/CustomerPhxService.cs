using System;
using System.Collections.Generic;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class CustomerPhxService : ICustomerPhxService
    {

        readonly ICustomerPhxRepository _customerRepo;

        public CustomerPhxService(ICustomerPhxRepository customerRepository)
        {
            _customerRepo = customerRepository;
        }



        public CustomerPhx CreateCustomer(Customer cust)
        {
            throw new NotImplementedException();
        }

        public CustomerPhx DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public CustomerPhx FindCustomerById(string id)
        {
            return _customerRepo.ReadById(id);
        }

        public CustomerPhx FindCustomerByIdIncludeOrders(string id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerPhx> GetAllByFirstName(string name)
        {
            throw new NotImplementedException();
        }

        public List<CustomerPhx> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public CustomerPhx NewCustomer(string firstName, string lastName, string address)
        {
            throw new NotImplementedException();
        }

        public CustomerPhx UpdateCustomer(CustomerPhx customerToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
