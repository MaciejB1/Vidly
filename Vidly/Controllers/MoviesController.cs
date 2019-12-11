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

        public ActionResult Details(int id)
        {
            var movieDetails = _Context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movieDetails == null)
            {
                return HttpNotFound();
            }

            return View(movieDetails);
        }

        public ActionResult New()
        {
            var genres = _Context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _Context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            else
            {
                if (movie.Id == 0)
                {
                    movie.DateAdded = DateTime.Today;
                    _Context.Movies.Add(movie);
                }
                else
                {
                    var movieInDb = _Context.Movies.Single(m => m.Id == movie.Id);
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.Name = movie.Name;
                    movieInDb.NumberInStock = movie.NumberInStock;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                }

                _Context.SaveChanges();

                return RedirectToAction("Index", "Movies");
            }
        }

        public ActionResult Edit(int id)
        {
            var movieToEdit = _Context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieToEdit == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movieToEdit,
                Genres = _Context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
//        public ActionResult New()
//        {
//
//            return View("MovieForm");
//        }
    }
}