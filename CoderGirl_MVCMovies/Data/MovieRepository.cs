using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRepository : IMovieRepository
    {
        static List<Movie> movies = new List<Movie>();
        static int nextId = 1;

        public Movie GetById(int id)
        {
            movies.SingleOrDefault(m=> m.?);
        }

        public List<Movie> GetMovies()
        {
            return movies;
        }

        public int Save(Movie movie)
        {
            movie.Id = nextId;
            //movie.Add(movie);
            return 0; //COMPLETE THIS SECTION
        }
    }
}
