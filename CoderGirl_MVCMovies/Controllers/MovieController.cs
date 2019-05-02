using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        public static IMovieRepository movieRepository = RepositoryFactory.GetMovieRepository();
        private static int nextIdToUse = 1; 

        public IActionResult Index()
        {
            List<Movie> movies = movieRepository.GetMovies();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOld(string movie)
        {
            
            return RedirectToAction(actionName: nameof(Index));
        }
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            movieRepository.Save(movie);
            return RedirectToAction(actionName: nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movie = movieRepository.getById(id);
            return View("Create" , movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            //TODO: update movie
            return RedirectToAction(actionName: nameof(Index));//THIS NEEDS TO BE EDITED
        }
    }
}