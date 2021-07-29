using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Vidly.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public DateTimeOffset Releasedate { get; set; }
    }
}