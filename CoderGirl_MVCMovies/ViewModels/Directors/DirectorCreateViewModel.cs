using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Directors
{
    public class DirectorCreateViewModel
    {
        private string nationality;

        [Required(ErrorMessage = "First Name must be included")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name must be included")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }        
        public string Nationality {
            get { return String.IsNullOrEmpty(nationality) ? "unknown" : nationality; }
            set { nationality = value; }
        }

        public void Persist()
        {
            Director director = new Director
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate,
                Nationality = this.Nationality
            };
            //Director director = new Director(this.FirstName, this.LastName, this.BirthDate, this.Nationality);
            RepositoryFactory.GetDirectorRepository().Save(director);
        }
    }
}
