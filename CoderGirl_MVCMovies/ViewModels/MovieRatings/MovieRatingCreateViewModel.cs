using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRatings
{
    public class MovieRatingCreateViewModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }



        public static MovieRatingCreateViewModel GetModel(int movieId)
        {
            var movie = (Movie)RepositoryFactory.GetMovieRepository().GetById(movieId);
            string movieName = movie.Name;
            MovieRating movieRating = new MovieRating();
            movieRating.MovieId = movieId;
            movieRating.MovieName = movieName;
            movieRating.Rating = 1;

            return new MovieRatingCreateViewModel
            {
                MovieId = movieRating.MovieId,
                MovieName = movieRating.MovieName,
                Rating = movieRating.Rating
            };
        }

        public void Persist()
        {
            MovieRating movieRating = new MovieRating
            {
                Id = this.Id,
                MovieName = this.MovieName,
                Rating = this.Rating,
                MovieId = this.MovieId
            };
            RepositoryFactory.GetMovieRatingRepository().Save(movieRating);
        }

    }
}
