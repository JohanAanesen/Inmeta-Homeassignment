﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmeta.Data;
using Inmeta.Models;

namespace Inmeta.Controllers
{
    [Route("api/[controller]")]
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
        public IEnumerable<Order> Get()
        {
            
            //Payload[] payloads = new Payload[_context.Order.Count()];
            //foreach (Order order in _context.Order){
            //    Customer customer = _context.Customer.FindAsync(order.CustomerId);

            //    Payload payload = new Payload();
            //}
            
            return _context.Order;
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

            //order doesnt exist 404
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

                //update customerId for order
                order.CustomerId = customer.Id;

            }
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            //201
            return CreatedAtAction("Get", new { id = order.OrderId }, order);
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}