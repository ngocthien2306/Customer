using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genres
    {
        [Key]
        public byte? MovieID { get; set; }

        [Required()]
        [StringLength(50)]
        [Display(Name = "Type of Musics")]
        public string Name { get; set; }
    }
}