using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(r=>r.UserId).NotEmpty();
            RuleFor(r => r.UserId).NotEqual(0);
            RuleFor(r=>r.CompanyName).NotEmpty();
           
        }
      
    }
}
