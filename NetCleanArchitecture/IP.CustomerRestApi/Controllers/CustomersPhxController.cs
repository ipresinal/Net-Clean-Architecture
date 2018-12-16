using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IP.CustomerRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersPhxController : ControllerBase
    {
        private readonly ICustomerPhxService _customerService;

        public CustomersPhxController(ICustomerPhxService customerPhxService)
        {
            _customerService = customerPhxService;
        }
          

        // GET api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<CustomerPhx> Get(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest("Parameter Id must be not null");

            //return  _customerService.FindCustomerById(id);
            return _customerService.FindCustomerById(id);
        }
    }
}