using System;
using System.Collections.Generic;
using System.Linq;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly CustomerAppContext _ctx;

        public CustomerRepository(CustomerAppContext ctx)
        {
            _ctx = ctx;
        }

        public Customer Create(Customer customer)
        {
            /*customer.Id = FakeDB.Id++;
            FakeDB.Customers.Add(customer);
            return customer;    */

            var cust =_ctx.Customers.Add(customer).Entity;
            _ctx.SaveChanges();
            return cust;
        }
       

        public IEnumerable<Customer> ReadAll()
        {
            //return FakeDB.Customers;

            return _ctx.Customers;
        }

        public Customer ReadById(int id)
        {
           /* return FakeDB.Customers.
                Select(c => new Customer()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    Address = c.Address,
                    LastName = c.LastName
                }).
                FirstOrDefault(c => c.Id == id);  */

            return _ctx.Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer FindCustomerByIdIncludeOrders(int id)
        {
            /*customer.Orders = _orderRepo.ReadAll().Where(order => order.Customer != null && order.Customer.Id == customer.Id).ToList(); */


            return _ctx.Customers.Include(c => c.Orders).FirstOrDefault(c => c.Id == id);

        }

        public Customer Update(Customer customerUpdate)
        {
            throw new NotImplementedException();
        }

        public Customer Delete(int id)
        {
            /*var ordersToRemove = _ctx.Orders.Where(o => o.Customer.Id == id);
            _ctx.RemoveRange(ordersToRemove);*/
            var custRemoved = _ctx.Remove(new Customer() {Id = id}).Entity;
            _ctx.SaveChanges();
            return custRemoved;
        }

        
    }
}
