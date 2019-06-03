using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieEditViewModel
    {
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public int DirectorId { get; set; }
        public int Year { get; set; }

        public static MovieEditViewModel GetModel(int id)
        {
            Movie movie = (Movie)RepositoryFactory.GetMovieRepository().GetById(id);
            return new MovieEditViewModel
            {
                Name = movie.Name,
                DirectorId = movie.DirectorId,
                DirectorName = movie.DirectorName,
                Year = movie.Year,
            };
        }

        public void Persist(int id)
        {
            Movie movie = new Movie
            {
                Id = id,
                Name = this.Name,
                DirectorId = this.DirectorId,
                DirectorName = this.DirectorName,
                Year = this.Year
            };
            RepositoryFactory.GetMovieRepository().Update(movie);
        }
    }
}
