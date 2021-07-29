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
        [StringLength(50)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name ="Subcribe")]
        public bool IsSubcribedToNewLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        [Display(Name = "Membership Type ID")]
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
    }
}