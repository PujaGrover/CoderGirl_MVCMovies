using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRatings
{
    public class MovieRatingIndexViewModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }


        public static List<MovieRatingIndexViewModel> GetMovieRatingList()
        {
            return RepositoryFactory.GetMovieRatingRepository()
                .GetModels()
                .Cast<MovieRating>()
                .Select(movieRating => GetMovieRatingIndexFromMovieRating(movieRating))
                .ToList();
        }
        private static MovieRatingIndexViewModel GetMovieRatingIndexFromMovieRating(MovieRating movieRating)
        {
            return new MovieRatingIndexViewModel
            {
                Id = movieRating.Id,
                //MovieName = movieRating.MovieName,
                MovieId = movieRating.MovieId,
                Rating = movieRating.Rating
            };
        }


    }
}
