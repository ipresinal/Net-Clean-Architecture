using System;
using System.Collections.Generic;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using CustomerApp.Infrastructure.Data.SqlHelper;
using Microsoft.Extensions.Configuration;

namespace CustomerApp.Infrastructure.Data.Repositories
{
    public class CustomerPhxRepository : ICustomerPhxRepository
    {
        string _connectionString;


        public CustomerPhxRepository(IDbSqlConnection conn)
        {
            _connectionString = conn.ConnectionString;
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
