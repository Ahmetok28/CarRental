using Business.Abstract;
using Bussines.Abstract;
using Bussines.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Entities.Concrete;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class FakePaymentManager : IPaymentService
    {
        IRentalService _rentalService;

        public FakePaymentManager(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        
        public IResult Pay(CreditCard card, Rental rental)
        {
            _rentalService.Add(rental);
            return new SuccessResult(Messages.AddRental);
        }
    }
}
