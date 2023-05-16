using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarDetailDtoValidator:AbstractValidator<CarDetailDto>
    {
        public CarDetailDtoValidator() 
        {

            RuleFor(c => c.BrandName).NotEmpty();
            RuleFor(c=>c.ColorName).NotEmpty();
        
        
        }
    }
}
