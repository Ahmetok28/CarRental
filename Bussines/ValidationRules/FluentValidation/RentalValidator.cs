using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {

        public RentalValidator()
        {
            RuleFor(x=>x.CarId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.RentDate.Day).GreaterThan(DateTime.Now.Day-3);
            
        }
    }
}
