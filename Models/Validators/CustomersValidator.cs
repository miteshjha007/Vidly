using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models.Validators
{
    public class CustomersValidator:AbstractValidator<Customers>
    {
        public CustomersValidator()
        {

            RuleFor(x => x.Name).Length(0, 50).WithMessage("Maximum Length of Name should be 50");
        }
    }
}