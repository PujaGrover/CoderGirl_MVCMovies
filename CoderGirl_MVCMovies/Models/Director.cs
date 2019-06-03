using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class Director : IModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string FullName
        {
            get { return $"{LastName}, {FirstName}"; }
        }


        //ANOTHER WAY TO LOWER THE REPETION OF CODE IN VIEWMODELS
        //THIS WAY IS PREFFERER THOUGH since it will not break the code
        //if the properties or director model is changed in any manner

        //The default constructor will be required to be created incase
        //we desire to create a specific contructor with set parameters.

        //public Director() { }

        

        //public Director(string firstName, string lastName, DateTime birthDate, string nationality)
        //{
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //    this.BirthDate = birthDate;
        //    this.Nationality = nationality;
        //}
    }
}
