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
        [Required(ErrorMessage ="Please enter customer's name.")]
        [StringLength(50)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name ="Subcribe")]
        public bool IsSubcribedToNewLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        [Required()]
        [Display(Name = "Membership Type ID")]
        public byte? MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        [IsMemberMin18YearOld]
        public DateTime? Birthdate { get; set; }
    }
}