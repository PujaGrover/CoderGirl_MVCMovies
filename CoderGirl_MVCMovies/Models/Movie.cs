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
        public string Director { get; set; }//CHANGE TO DirectorName to be specific
        public int Year { get; set; }
        public List<int> Ratings { get; set; }
        public int DirectorId { get; set; }
    }
}
