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
            return View();
        }
        public ActionResult Create()
        {
            var membershipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MemberShipTypes = membershipTypes
            };

            return View("Create", viewModel);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = _context.Customers.Find(id)
            };
            
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View("Delete", viewModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };

                return View("Create", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubcribedToNewLetter = customer.IsSubcribedToNewLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Details(int? id)
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
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };
            return View("Create", viewModel);
        }
    }
}