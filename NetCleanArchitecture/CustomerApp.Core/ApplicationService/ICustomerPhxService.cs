using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICustomerPhxService
    {
        /// <summary>
        /// New Customer
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        CustomerPhx NewCustomer(string firstName, string lastName, string address);

        /// <summary>
        /// Create --> PUT
        /// </summary>
        /// <param name="cust"></param>
        /// <returns></returns>
        CustomerPhx CreateCustomer(Customer cust);

        /// <summary>
        /// Read by Id   --> GET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerPhx FindCustomerById(string id);

        /// <summary>
        /// Read by Id   --> GET
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerPhx FindCustomerByIdIncludeOrders(string id);

        /// <summary>
        /// Read All --> GET
        /// </summary>
        /// <returns></returns>
        List<CustomerPhx> GetAllCustomers();

        /// <summary>
        /// Read by First name  --> GET
        /// </summary>
        /// <returns></returns>
        List<CustomerPhx> GetAllByFirstName(string name);

        /// <summary>
        /// Update    --> PUT
        /// </summary>
        /// <param name="customerToUpdate"></param>
        /// <returns></returns>
        CustomerPhx UpdateCustomer(CustomerPhx customerToUpdate);

        /// <summary>
        /// Delete -> Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CustomerPhx DeleteCustomer(string id);
    }
}
