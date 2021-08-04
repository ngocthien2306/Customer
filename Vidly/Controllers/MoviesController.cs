using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            if (User.IsInRole(RolesName.CanManagerMovies))
                return View("List");
            return View("ReadOnlyList");
        }
        [Authorize(Roles = RolesName.CanManagerMovies)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Movie = new Movie(),
                Genres = genre
            };
            return View("New", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var newMovieView = new NewMovieViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("New", newMovieView);
            }
            if(movie.MovieID == 0)
            {
                movie.DayAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.MovieID == movie.MovieID);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.Country = movie.Country;
                movieInDb.Releasedate = movie.Releasedate;
                movieInDb.AmountOfRock = movie.AmountOfRock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
                
        }
        public ActionResult Detail(int? id)
        {
            var movie = _context.Movies.Include(m => m.Genres).SingleOrDefault(m => m.MovieID == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
    }
}