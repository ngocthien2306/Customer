using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                return Customer.Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
    }
}