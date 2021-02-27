using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Vidly.Models;
using System.Web.Http;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private VidlyDb _context;
        public CustomersController()
        {
            _context = new VidlyDb(); 
        }
        // Get/api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customers , CustomerDto>); //Mapping Customer Obj to Customer Dto by using linq ext method(.select)
        }
        // Get/api/customers/1
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customers, CustomerDto>(customer));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer (CustomerDto customersDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customers>(customersDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customersDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customersDto);
        }
        // PUT /api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomers(int id, CustomerDto customersDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customersDto, customerInDb);
            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
