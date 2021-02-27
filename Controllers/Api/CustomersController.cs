﻿using System;
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
        public CustomerDto GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customers, CustomerDto>(customer);
        }
        // POST /api/customers
        [HttpPost]
        public CustomerDto CreateCustomer (CustomerDto customersDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customers>(customersDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customersDto.Id = customer.Id;
            return customersDto;
        }
        // PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomers(int id, CustomerDto customersDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customersDto, customerInDb);
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