using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genres
    {
        public byte MovieID { get; set; }

        [Required()]
        [StringLength(50)]
        public string Name { get; set; }
    }
}