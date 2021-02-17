using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Customers()
        {
            var customers = new List<Customers>
            {
                new Customers { Name = "Customer1"},
                new Customers { Name = "Customer2"},
            };

            var viewModel = new RandomMovieViewModel
            {

                Customers = customers
            };
            return View(viewModel);
        }
    }
}