using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int  DirectorId  { get; set; }
        public string DirectorName { get; set; }
        public List<int> Ratings { get; set; }
        //public double AverageRating
        //{
        //    get {if (Ratings.Count > 0)
        //        {
        //            return Ratings.Average();
        //        }
        //        else return 0;
        //    }
        //    set {; }
        //}
        //public int NumberOfRatings
        //{
        //    get {return Ratings.Count; }
        //    set {; }
        //}

        public static List<MovieIndexViewModel> GetMovieList()
        {
            return RepositoryFactory.GetMovieRepository().GetModels()
                .Cast<Movie>()
                .Select(movie => GetMovieIndexFromViewModel(movie))
                .ToList();
        }
        private static MovieIndexViewModel GetMovieIndexFromViewModel(Movie movie)
        {
            return new MovieIndexViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                Year = movie.Year,
                DirectorId = movie.DirectorId,
                DirectorName = movie.DirectorName,
                Ratings = movie.Ratings
            };
        }
    }
}
