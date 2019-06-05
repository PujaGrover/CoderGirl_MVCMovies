﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using CoderGirl_MVCMovies.ViewModels.MovieRatings;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        private IRepository movieRespository = RepositoryFactory.GetMovieRepository();

       public IActionResult Index()
        {
            //List<MovieRating> movieRatings = ratingRepository.GetModels().Cast<MovieRating>().ToList();
            var model = MovieRatingIndexViewModel.GetMovieRatingList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int movieId)
        {
            //var movie = (Movie)movieRespository.GetById(movieId);
            //string movieName = movie.Name;
            //MovieRating movieRating = new MovieRating();
            //movieRating.MovieId = movieId;
            //movieRating.MovieName = movieName;
            //return View(movieRating);
            MovieRatingCreateViewModel model = MovieRatingCreateViewModel.GetModel(movieId);
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(int movieId, MovieRatingCreateViewModel model)
        {
            model.Persist();
            return RedirectToAction(controllerName: nameof(Movie), actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieRatingEditViewModel model = MovieRatingEditViewModel.GetModel(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieRatingEditViewModel model)
        {
            model.Persist(id);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            RepositoryFactory.GetMovieRatingRepository().Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}