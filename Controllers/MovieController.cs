using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Movies()
        {
            //var movie = new Movie()
            //{
            //    Name = "Shrek!"
            //};
            var movie = new List<Movie>
            {
                new Movie{ Name = "Shrek!"},
                new Movie { Name = "Ghost"}
            };
            var viewModel = new RandomMovieViewModel
            {

                Movie = movie
            };
            return View(viewModel);

            //var customers = new List<Customers>
            //{
            //    new Customers { Name = "Customer1"},
            //    new Customers { Name = "Customer2"},
            //};

            //var viewModel = new RandomMovieViewModel
            //{
            //    Movie = movie,
            //    Customers=customers
            //};
            //return View(viewModel);
        }
        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        //public ActionResult ByReleaseDate(int year, int month)            
        //{                                                             //using attribute routing with applying constraints
        //    return Content(year + "/" + month);
        //}
    }
}