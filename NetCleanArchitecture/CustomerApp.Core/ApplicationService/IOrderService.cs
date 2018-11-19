using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface IOrderService
    {
        /// <summary>
        /// New Order
        /// </summary>
        /// <returns></returns>
        Order New();

        /// <summary>
        /// Create --> POST
        /// </summary>
        /// <returns></returns>
        Order CreateOrder(Order order);

        /// <summary>
        /// Read --> GET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Order FindOrderById(int id);
        List<Order> GetAllOrders();

        /// <summary>
        /// Update --> PUT
        /// </summary>
        /// <param name="orderUpdate"></param>
        /// <returns></returns>
        Order UpdateOrder(Order orderUpdate);

        /// <summary>
        /// Delete --> DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Order DeleteOrder(int id);
    }
}
