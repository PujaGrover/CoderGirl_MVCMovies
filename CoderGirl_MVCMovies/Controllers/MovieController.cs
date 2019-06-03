﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using CoderGirl_MVCMovies.ViewModels.Movies;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        static IRepository movieRepository = RepositoryFactory.GetMovieRepository();
        static IRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public IActionResult Index()
        {
            var movies = MovieIndexViewModel.GetMovieList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            MovieCreateViewModel model = new MovieCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel model)
        {
            //if (String.IsNullOrWhiteSpace(model.Name))
            //{
            //    ModelState.AddModelError("Name", "Name must be included");
            //}
            if(model.Year < 1888 || model.Year > DateTime.Now.Year)
            {
                ModelState.AddModelError("Year", "Year is not valid");
            }

            if(ModelState.ErrorCount > 0)
            {
                return View(model);
            }

            model.Persist();
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieEditViewModel model = MovieEditViewModel.GetModel(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieEditViewModel model)
        {
            //since id is not part of the edit form, it isn't included in the model, thus it needs to be set from the route value
            //there are alternative patterns for doing this - for one, you could include the id in the form but make it hidden
            //feel free to experiment - the tests wont' care as long as you preserve the id correctly in some manner
            model.Persist(id);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //**movieRepository.Delete(id);
            RepositoryFactory.GetMovieRepository().Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}