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
    public class CustomersController : Controller
    {
        private VidlyDb _context;
        public CustomersController()
        {
            _context = new VidlyDb();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customers = new Customers(),
                memberShipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customers)
        {
           if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customers = customers,
                    memberShipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }
            if(customers.Id == 0)
            {
                _context.Customers.Add(customers);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customers.Id);
                customerInDb.Name = customers.Name;
                customerInDb.Birthdate = customers.Birthdate;                               //Updating Customer
                customerInDb.MembershipTypeId = customers.MembershipTypeId;
                customerInDb.IsSubscribeToNewsletter = customers.IsSubscribeToNewsletter;
            }
           // _context.Customers.Add(customers);
            _context.SaveChanges();

            return RedirectToAction("Customers", "Customers");
        }
        // GET: Customers
        public ViewResult Customers()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();
            return View(customers);
        }
        //public ActionResult Details(int id)
        //{
        //    var customers = _context.Customers.SingleOrDefault(x => x.Id == id);
        //    if (customers == null)
        //        return HttpNotFound();
        //    return View(customers);
        //}

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customers = customer,
                memberShipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm" , viewModel);
        }
    }
}