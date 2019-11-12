using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _Context { get; set; }

        public MoviesController()
        {
            _Context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _Context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int? Id)
        {
            var movieDetails = _Context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);

            if (movieDetails == null)
            {
                return HttpNotFound();
            }

            return View(movieDetails);
        }
    }
}