using System;
using System.Collections.Generic;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace IP.CustomerRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET api/Orders  ---> READ ALL
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(_orderService.GetAllOrders());
        }

        // GET api/Orders/5  ---> READ BY ID
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            if (id < 1)
            {
                return BadRequest("Parameter Id must be greater than zero");
            }

            return Ok();
        }

        // POST api/Orders ---> CREATE
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            try
            {
                return Ok(_orderService.CreateOrder(order));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        // PUT api/Orders/5 ---> UPDATE
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            if (id < 1 || id != order.Id)
            {
                return BadRequest("Parameter Id and Order Id must be the same");
            }

            return Ok();
        }

        // DELETE api/Customers/5  ---> DELETE
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {          
            return Ok($"Order with ID: {id} was deleted");
        }

    }
}