using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesViewModel
    {
        public List<Movie> Movies { get; set; }

        public MoviesViewModel()
        {
            Movies = new List<Movie>()
            {
                new Movie { Name = "Shrek", Id = 1 },
                new Movie { Name = "Wall-e", Id = 2 }
            };
        }
    }
}