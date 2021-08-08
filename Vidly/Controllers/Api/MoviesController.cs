using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.App_Start;
using AutoMapper;
using System.Data.Entity;
namespace Vidly.Models.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetMovies(string query = null)
        {
            var movieQuery = _context.Movies.Include(g => g.Genres).Where(m => m.NumberAvailable > 0);
            if (!String.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(m => m.Name.Contains(query));
            var movieDto = movieQuery.ToList().Select(Mapper.Map<Movie, MovieDTO>);
            return Ok(movieDto);
        }

        public IHttpActionResult GetDataMovies(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.MovieID == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }
        [HttpPost]
        [Authorize(Roles = RolesName.CanManagerMovies)]
        public IHttpActionResult CreateCustomer(MovieDTO movieDTO)
        {
            if (ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDTO.MovieID = (int)movie.MovieID;

            return Created(new Uri(Request.RequestUri + "/" + movie.MovieID), movieDTO);
        }
        [HttpPut]
        [Authorize(Roles = RolesName.CanManagerMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.MovieID == id);
            if (!ModelState.IsValid)
                return BadRequest();
            if (movieInDb == null)
                return NotFound();
            Mapper.Map(movieDTO, movieInDb);
            movieInDb.Name = movieDTO.Name;
            movieInDb.Genre = movieDTO.Genre;
            movieInDb.Country = movieDTO.Country;
            movieInDb.AmountOfRock = movieDTO.AmountOfRock;
            movieInDb.Releasedate = movieDTO.Releasedate;
            _context.SaveChanges();
            return Ok();
        }
        //Delete api/movies/1
        [HttpDelete]
        [Authorize(Roles = RolesName.CanManagerMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.MovieID == id);
            if (!ModelState.IsValid)
                return BadRequest();
            if (movie == null)
                return NotFound();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
