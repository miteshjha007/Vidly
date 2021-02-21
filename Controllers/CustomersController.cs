using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;

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

        // GET: Customers
        public ViewResult Customers()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();
            return View(customers);
            //var customers = new List<Customers>
            //{
            //    new Customers { Name = "Customer1"},9
            //    new Customers { Name = "Customer2"},
            //};

            //var viewModel = new RandomMovieViewModel
            //{

            //    Customers = customers
            //};
            //return View(viewModel);
        }
        public ActionResult Details(int id)
        {
            var customers = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customers == null)
                return HttpNotFound();
            return View(customers);
        }
        //private IEnumerable<Customers> GetCustomers()
        //{
        //    return new List<Customers>
        //    {
        //        new Customers {Id=1 , Name="Test1"},
        //        new Customers {Id=2 , Name="Test2"}

        //    };
        //}
    }
}