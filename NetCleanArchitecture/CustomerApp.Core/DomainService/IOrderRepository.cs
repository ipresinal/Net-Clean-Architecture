using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Create Data
        /// No Id when enter, but Id when exits
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Order Create(Order order);
        /// <summary>
        /// Read Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Order ReadById(int id);
        IEnumerable<Order> ReadAll();
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="OrderUpdate"></param>
        /// <returns></returns>
        Order Update(Order OrderUpdate);
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Order Delete(int id);
    }
}
