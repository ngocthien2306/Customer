using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
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
        
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(m => m.Genres).ToList();
            return View(movie);
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };
            return View("Create", viewModel);
        }
        
    }
}