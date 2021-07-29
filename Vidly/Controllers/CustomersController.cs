using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Net;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();

            return View(customers);
        }
        public ViewResult New()
        {
            var memberShipType = _context.MemberShipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                MemberShipTypes = memberShipType
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,IsSubcribedToNewLetter,MembershipTypeId,Birthdate")]Customer newCustomer)
        {
            if(ModelState.IsValid)
            {
                _context.Customers.Add(newCustomer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newCustomer);

        }
        public ActionResult Details(int?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}