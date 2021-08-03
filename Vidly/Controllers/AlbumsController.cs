using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Migrations;
namespace Vidly.Controllers
{
    public class AlbumsController : Controller
    {
        private ApplicationDbContext _context;
        public AlbumsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Albums
        public ActionResult Index()
        {
            return View();
        }
    }
}