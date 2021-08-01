using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DTO;

namespace Vidly.Models.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        //Get api/customer
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO> );
        }
        //Get api/customer/1
        public IHttpActionResult GetDataCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }
        //Post /api/customer
        [HttpPost] 
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        //Put /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerInDb);
            customerInDb.Name = customerDto.Name;
            customerInDb.Birthdate = customerDto.Birthdate;
            customerInDb.IsSubcribedToNewLetter = customerDto.IsSubcribedToNewLetter;
            customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
            _context.SaveChanges(); 
        }
        //Delete /api/customer/1
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
