using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
//        public ActionResult Index(int? pageIndex, string sortBy)
//        {
//            return View();
//        }
//
//        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
//        public ActionResult ByReleaseDate(int year, int month)
//        {
//            return Content(year + "/" + month);
//        }

        public ActionResult Random()
        {
            var movies = new List<Movie>        //hard code data
            {
                new Movie() {Name = "Shrek"},
                new Movie() {Name = "Joker"}
            };

            var moviesViewModel = new MovieViewModel
            {
                Movies = movies
            };

            return View(moviesViewModel);
        }
    }
}