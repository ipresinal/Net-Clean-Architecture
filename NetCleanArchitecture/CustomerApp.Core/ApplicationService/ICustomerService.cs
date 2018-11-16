using System;
using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService
{
    public interface ICustomerService
    {
        /// <summary>
        /// New Customer
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        Customer NewCustomer(string firstName, string lastName, string address);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="cust"></param>
        /// <returns></returns>
        Customer CreateCustomer(Customer cust);

        /// <summary>
        /// Read by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Customer FindCustomerById(int id);

        /// <summary>
        /// Read All
        /// </summary>
        /// <returns></returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// Read by First name
        /// </summary>
        /// <returns></returns>
        List<Customer> GetAllByFirstName(string name);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="customerToUpdate"></param>
        /// <returns></returns>
        Customer UpdateCustomer(Customer customerToUpdate);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Customer DeleteCustomer(int id);


    }
}
