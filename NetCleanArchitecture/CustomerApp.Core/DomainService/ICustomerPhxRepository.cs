
using System.Collections.Generic;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.DomainService
{
    public interface ICustomerPhxRepository
    {
        // Customer Repository Interface

        // Create Data
        // No Id when enter, with Id when exist
        CustomerPhx Create(CustomerPhx customer);

        // Read Data
        CustomerPhx ReadById(string id);
        IEnumerable<CustomerPhx> ReadAll();
        CustomerPhx FindCustomerByIdIncludeOrders(string id);

        // Update Data
        CustomerPhx Update(CustomerPhx customerUpdate);

        // Delete Data
        CustomerPhx Delete(string id);
    }
}
