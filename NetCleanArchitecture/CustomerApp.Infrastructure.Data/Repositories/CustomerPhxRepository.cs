using System;
using System.Collections.Generic;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.Data.Repositories
{
    public class CustomerPhxRepository : ICustomerPhxRepository
    {

        public CustomerPhxRepository()
        {
            
        }


        public CustomerPhx Create(CustomerPhx customer)
        {
            throw new NotImplementedException();
        }

        public CustomerPhx Delete(string id)
        {
            throw new NotImplementedException();
        }

        public CustomerPhx FindCustomerByIdIncludeOrders(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerPhx> ReadAll()
        {
            throw new NotImplementedException();
        }

        public CustomerPhx ReadById(string id)
        {
            throw new NotImplementedException();
        }

        public CustomerPhx Update(CustomerPhx customerUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
