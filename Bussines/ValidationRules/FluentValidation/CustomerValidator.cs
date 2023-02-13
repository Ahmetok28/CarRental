using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x=>x.UserId).NotEmpty();
            RuleFor(x=>x.CompanyName).NotEmpty();
            RuleFor(x => x.CompanyName).MinimumLength(2);
        }

    }
}
