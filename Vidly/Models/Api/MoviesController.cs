using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.App_Start;
using AutoMapper;

namespace Vidly.Models.Api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetMovies()
        {
            var musicDto = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
            return Ok(musicDto);
        }
        public IHttpActionResult GetDataMovies(byte id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.MovieID == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }
        [HttpPost]
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
        public void UpdateMovie(int id, MovieDTO movieDTO)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.MovieID == id);
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDTO, movieInDb);
            movieInDb.Name = movieDTO.Name;
            movieInDb.Genre = movieDTO.Genre;
            movieInDb.Country = movieDTO.Country;
            movieInDb.AmountOfRock = movieDTO.AmountOfRock;
            movieInDb.Releasedate = movieDTO.Releasedate;
            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.MovieID == id);
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
