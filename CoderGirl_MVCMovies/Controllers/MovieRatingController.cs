using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository repository = RepositoryFactory.GetMovieRatingRepository();

        /// TODO: Create a view Index. This view should list a table of all saved movie names with associated average rating
        /// TODO: Be sure to include headers for Movie and Rating
        /// TODO: Each tr with a movie rating should have an id attribute equal to the id of the movie rating
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {
            return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });
        }

        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            ViewBag.Movie = movieName;
            ViewBag.Rating = rating;
            return View();
        }
    }
}