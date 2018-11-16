
using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface ICustomerRepository
    {
        // Customer Repository Interface

        // Create Data
        // No Id when enter, with Id when exist
        Customer Create(Customer customer);

        // Read Data
        Customer ReadById(int id);
        IEnumerable<Customer> ReadAll();

        // Update Data
        Customer Update(Customer customerUpdate);

        // Delete Data
        Customer Delete(int id);

    }
}
