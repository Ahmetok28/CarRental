using Bussines.Abstract;
using Bussines.BusinessAspects.Autofac;
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
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

       // [SecuredOperation("admin")]
        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.Id == id));
        }

       // [SecuredOperation("admin")]
        public IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CustomerId == customerId));
        }

        //[SecuredOperation("admin")]
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);

            return new SuccessResult(Messages.CreditCardAdded);
        }

       // [SecuredOperation("admin")]
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);

            return new SuccessResult(Messages.CreditCardDeleted);
        }
    }
}
