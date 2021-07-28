using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required()]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        public bool IsSubcribedToNewLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
    }
}