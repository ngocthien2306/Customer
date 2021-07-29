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
        [Required()]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(15)]
        public string Genre { get; set; }
        [StringLength(20)]
        public string Country { get; set; }
        public DateTimeOffset? Releasedate { get; set; }
    }
}