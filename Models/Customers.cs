using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models.Validators;
using FluentValidation.Attributes;

namespace Vidly.Models
{
    [Validator(typeof(CustomersValidator))]
    public class Customers
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsSubscribeToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membershipe Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}