using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDTO rentalDto)
        {
            var customers = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.MovieID)).ToList();

            foreach(var movie in movies)
            {
                if(movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customers,
                    Movie = movie,
                    DayRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
