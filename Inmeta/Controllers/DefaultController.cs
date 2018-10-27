using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmeta.Data;
using Inmeta.Models;
using System.Data.Entity;
using Microsoft.AspNetCore.Cors;

namespace Inmeta.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        private readonly InmetaContext _context;

        public DefaultController(InmetaContext context)
        {
            _context = context;
        }

        // GET: api/Default
        [HttpGet]
        public Payload[] Get()
        {
            //all orders
            IEnumerable<Order> orders = _context.Order;
            //Array to keep all payloads in
            Payload[] payloads = new Payload[_context.Order.Count()];

            int iterator = 0;

            //for all orders, get customer belonging to the order, make a payload and add to array
            foreach (Order order in orders)
            {
                Customer customer = _context.Customer
                                .Where(cust => cust.Id == order.CustomerId)
                                .FirstOrDefault();

                if (customer != null)
                {
                    payloads[iterator++] = new Payload(customer, order);
                }

            }

            return payloads;
        }

        // GET: api/Default/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //find order in db
            Order order = await _context.Order.FindAsync(id);

            //order doesnt exist, return 404
            if (order == null)
            {
                return NotFound();
            }

            //find customer that owns order
            Customer customer = await _context.Customer.FindAsync(order.CustomerId);
            //make payload
            Payload payload = new Payload(customer, order);
            //200
            return Ok(payload);
        }

        // POST: api/Default
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Payload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //get order from payload
            Order order = payload.GetOrder();

            //check if customer exist
            Customer customer = _context.Customer
                                .Where(cust => cust.Name == payload.Name)
                                .FirstOrDefault();
            
            if(customer == null)//customer does not exist
            {
                //since customer does not exist, add customer to db
                customer = payload.GetCustomer();
                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();

            }

            //update customerId for order
            order.CustomerId = customer.Id;

            order.OrderDate = DateTime.Now;

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            //201
            return CreatedAtAction("Get", new { id = order.OrderId }, order);
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Payload payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //new order from request
            Order newOrder = payload.GetOrder();

            //get old order from db
            Order result = _context.Order
                            .Where(b => b.OrderId == id)
                            .FirstOrDefault();

            if(result != null)
            {
                //updates all the fields
                result.AddressFrom = newOrder.AddressFrom;
                result.AddressTo = newOrder.AddressTo;
                result.Service = newOrder.Service;
                result.DoDate = newOrder.DoDate;
                result.Info = newOrder.Info;
              
                //saves changes
                await _context.SaveChangesAsync();
            }
            //204
            return NoContent();
        }

        // DELETE: api/Default/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //get order
            var order = await _context.Order.FindAsync(id);
            //doesnt exist -> 404
            if (order == null)
            {
                return NotFound();
            }

            //remove and save
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            //200
            return Ok(order);
        }
    }
}
