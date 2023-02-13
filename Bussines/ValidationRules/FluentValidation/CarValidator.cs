using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.ModelYear).NotEmpty();
            RuleFor(x=>x.ModelYear).GreaterThan(2000);

        }
    }
}
