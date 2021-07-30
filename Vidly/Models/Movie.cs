using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Vidly.Models
{
    public class Movie
    {
        public int? MovieID { get; set; }

        [Required()]
        [StringLength(50)]
        public string Name { get; set; }

        public Genres Genres { get; set; }

        [Required()]
        public byte Genre { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [Display(Name = "Release Day")]
        public DateTimeOffset? Releasedate { get; set; }

        public DateTime DayAdded { get; set; }

        [Display(Name = "Number of Rock")]
        [Range(1, 20)]
        public byte AmountOfRock { get; set; }
    }
}