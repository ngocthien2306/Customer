using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class IsMemberMin18YearOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MemberShipType.Unknown || customer.MembershipTypeId == MemberShipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("The Customer must be at least 18 year old to go on a membership");
        }
    }
}