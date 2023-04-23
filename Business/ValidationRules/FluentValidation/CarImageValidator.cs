using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    internal class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator() 
        {
            RuleFor(c => c.ImagePath).NotEmpty();
            
           
        }

    }
}
