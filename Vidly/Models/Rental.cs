﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required()]
        public Movie Movie { get; set; }
        [Required()]
        public Customer Customer { get; set; }
        public DateTime DayRented { get; set; }
        public DateTime? DayReturned { get; set; }
    }
}