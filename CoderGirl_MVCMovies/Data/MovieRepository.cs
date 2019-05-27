using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
     internal class MovieRepository : BaseRepository
    {
        //static List<Movie> movies = new List<Movie>();  DELETE THIS CODE
        //static int nextId = 1;
        static IRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        static IRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        //public void Delete(int id)
        //{
        //    movies.RemoveAll(m => m.Id == id);
        //}

        public override IModel GetById(int id)
        {
            //Movie movie = models.SingleOrDefault(m => m.Id == id);
            Movie movie = (Movie)base.GetById(id);
            movie = SetMovieRatings(movie);
            movie = SetDirectorName(movie);
            return movie;
        }

        public override List<IModel> GetModels()
        {
            return models.Select(movie => SetMovieRatings(movie))
                .Select(movie => SetDirectorName(movie)).ToList();
        }

        //public int Save(Movie movie)  DELETE THIS CODE NOW
        //{
        //    movie.Id = nextId++;
        //    movies.Add(movie);
        //    return movie.Id;
        //}

        //public void Update(Movie movie)
        //{
        //    this.Delete(movie.Id);
        //    movies.Add(movie);
        //}

        private Movie SetMovieRatings(Movie movie)
        {
            List<int> ratings = ratingRepository.GetMovieRatings()
                                                .Where(rating => rating.MovieId == movie.Id)
                                                .Select(rating => rating.Rating)
                                                .ToList();
            movie.Ratings = ratings;
            return movie;
        }

        private Movie SetDirectorName(Movie movie)
        {
            Director director = directorRepository.GetById(movie.DirectorId);
            movie.DirectorName = director.FullName;
            return movie;
        }
    }
}
