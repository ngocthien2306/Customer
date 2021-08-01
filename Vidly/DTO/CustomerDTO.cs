using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
namespace Vidly.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsSubcribedToNewLetter { get; set; }
        public byte? MembershipTypeId { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}