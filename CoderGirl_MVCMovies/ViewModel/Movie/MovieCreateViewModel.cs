using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModel.Movie
{
    public class MovieCreateViewModel
    {
        public static MovieCreateViewModel GetMovieCreateViewModel()
        {
           // MovieCreateViewModel viewModel = new MovieCreateViewModel();
            List<Director> directors = RepositoryFactory.GetDirectorRepository()
                                                        .GetModels()
                                                        .Cast<Director>()
                                                        .ToList();
            //viewModel.Directors = directors;
            // return viewModel;
            return new MovieCreateViewModel(directors);
        }

        public string Name { get; set; }
        public int DirectorId { get; set; }
        public List<Director> Directors { get; set; }
        public int Year { get; set; }

        private MovieCreateViewModel(List<Director> directors)
        {
            this.Directors = directors;
        }

        public void Persist()// this is an instance method
        {
            Models.Movie movie = new Models.Movie
            {
                Name = this.Name,
                DirectorId = this.DirectorId,
                Year = this.Year
            };
            RepositoryFactory.GetMovieRepository().Save(movie);
        }
    }
}
