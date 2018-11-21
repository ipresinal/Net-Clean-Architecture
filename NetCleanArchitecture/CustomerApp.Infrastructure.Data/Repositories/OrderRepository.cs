using System;
using System.Collections.Generic;
using System.Text;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly CustomerAppContext _ctx;

        public OrderRepository(CustomerAppContext ctx)
        {
            _ctx = ctx;    
        }


        public Order Create(Order order)
        {
            throw new NotImplementedException();
        }

        public Order Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> ReadAll()
        {
            return _ctx.Orders;
        }

        public Order ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order OrderUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
