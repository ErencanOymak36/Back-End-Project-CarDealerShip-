using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
       public CarValidator() 
        {
            RuleFor(c=>c.BrandId).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(540000);
            RuleFor(c => c.Description).MaximumLength(200);

        
        
        
        }
    }
}
