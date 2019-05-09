using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class MovieRating
    {
        public int Id { get; set; }
        public string MovieName { get; set; } //Changed from Movie to MovieName
        public int Rating { get; set; }
        public int MovieId { get; set; }
    }
}
