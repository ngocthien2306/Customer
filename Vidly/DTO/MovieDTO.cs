using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTO
{
    public class MovieDTO
    {
        public int MovieID { get; set; }

        [Required()]
        [StringLength(50)]
        public string Name { get; set; }
        public byte Genre { get; set; }
        public string Country { get; set; }
        public DateTime? Releasedate { get; set; }
        public GenreDTO Genres { get; set; }
        public DateTime DayAdded { get; set; }
        [Range(1, 20)]
        public byte AmountOfRock { get; set; }
    }
}