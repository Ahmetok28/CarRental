using Bussines.Abstract;
using Bussines.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class PaymentManager : IPaymentService
    {

        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment entity)
        {
            _paymentDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Payment entity)
        {
            _paymentDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IResult Pay(Payment entity)
        {
            var result = _paymentDal.Get(p =>
           p.FullName == entity.FullName
           && p.CardNumber == entity.CardNumber
           && p.Months == entity.Months
           && p.Year == entity.Year
           && p.CVV == entity.CVV
           );

            if (result != null)
            {
                return new SuccessResult(Messages.PayIsSuccessfull);
            }
            return new ErrorResult(Messages.CardInformationIsIncorrect);
        }

        public IResult Update(Payment entity)
        {
            _paymentDal.Update(entity);
            return new SuccessResult();
        }
    }
}
