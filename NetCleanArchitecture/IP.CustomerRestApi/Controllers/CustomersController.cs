using System.Collections.Generic;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace IP.CustomerRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        // GET api/Customers  ---> READ ALL
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return _customerService.GetAllCustomers();
        }

        // GET api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            if (id < 1) return BadRequest("Parameter Id must be greater than zero");
            
            //return  _customerService.FindCustomerById(id);
            return _customerService.FindCustomerByIdIncludeOrders(id);
        }

        // POST api/Customers  ---> CREATE JSON
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FirstName))
            {
                return BadRequest("Firstname is required for creating customer");
            }

            if (string.IsNullOrEmpty(customer.LastName))
            {
                return BadRequest("LastName is required for creating customer");
            }

            //return StatusCode(500, "Horrible error CALL Tech Support");

            return  _customerService.CreateCustomer(customer);
        }

        // PUT api/Customers/5
        [HttpPut("{id}/{value}")]
        public ActionResult<Customer> Put(int id, string value ,[FromBody] Customer customer)
        {
            if (id < 1 ||  id != customer.Id)
            {
                return BadRequest("Parameter and customer Id must be the same");
            }

            return Ok(_customerService.UpdateCustomer(customer));
        }

        // DELETE api/Customers/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest("Parameter Id must be greater than zero");
            }

            var customer = _customerService.DeleteCustomer(id);

            if (customer == null)
            {
                return StatusCode(404, "Did not find Customer with ID" + id);
            }

            return Ok($"Customer with ID: {id} was deleted");
        }
    }
}
