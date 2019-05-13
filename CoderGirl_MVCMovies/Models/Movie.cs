using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class Movie
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public int Year { get; set; }
        public List<int> Ratings { get; set; }
        public int DirectorId { get; set; }

        //MODELS should not preferably have methods, this will be an exception
        public string AverageRating(List<int> Ratings)
        {
            double averageRating;
            if (Ratings.Count == 0)
                return "none";

            else
                averageRating = Ratings.Average();
                return averageRating.ToString();
        }
    }
}
