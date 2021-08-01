using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genres> Genres { get; set; }
        public Movie Movie { get; set; }
        public int? MovieID { get; set; }

        [Required()]
        [StringLength(50)]
        public string Name { get; set; }

        [Required()]
        public string Genre { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [Display(Name = "Release Day")]
        public DateTimeOffset? Releasedate { get; set; }

        [Display(Name = "Number of Rock")]
        [Range(1, 20)]
        public byte? AmountOfRock { get; set; }

        public string Title
        {
            get
            {
                return MovieID != 0 ? "Edit Movie" : "New Movie";
            }
        }
        public NewMovieViewModel()
        {
            MovieID = 0;
        }
        public NewMovieViewModel(Movie movie)
        {
            MovieID = movie.MovieID;
            Name = movie.Name;
            Releasedate = movie.Releasedate;
            Country = movie.Country;
            Genre = movie.Genre;
            AmountOfRock = movie.AmountOfRock;
        }
    }
}