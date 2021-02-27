using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.Models.Validators;

namespace Vidly.Dtos
{
    [Validator(typeof(CustomersValidator))]
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsSubscribeToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}