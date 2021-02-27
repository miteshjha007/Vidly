using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Vidly.Models;
using System.Web.Http;

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
        public IEnumerable<Customers> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        // Get/api/customers/1
        public Customers GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }
        // POST /api/customers
        [HttpPost]
        public Customers CreateCustomer (Customers customers)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customers);
            _context.SaveChanges();
            return customers;
        }
        // PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomers(int id, Customers customers)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customers.Name;
            customerInDb.Birthdate = customers.Birthdate;
            customerInDb.IsSubscribeToNewsletter = customers.IsSubscribeToNewsletter;
            customerInDb.MembershipTypeId = customers.MembershipTypeId;
            _context.SaveChanges();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
