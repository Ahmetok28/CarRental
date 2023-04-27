using Business.Abstract;
using Bussines.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckAvailability(rental.CarId,rental.RentDate));
            if (result!=null)
            {
                return result;
                
            }
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
        public IResult CheckCarStatus(Rental rental)
        {
            if (_rentalDal.CheckCarStatus(rental.CarId, rental.RentDate, rental.ReturnDate))
            {
                return new SuccessResult(Messages.RentalDateOk);
            }
            return new ErrorResult(Messages.RentalReturnDateError);
        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }
        public IDataResult<List<Rental>> GetRentalByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.CarId==carId));
        }

        public IDataResult<List<RentalDetailDto>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CustomerId == customerId));
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId));
        }


        private IResult CheckAvailability(int carId, DateTime newRentDate)
        {
            var result =_rentalDal.GetAll(c => c.CarId == carId);
            if (result!= null)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i].ReturnDate > newRentDate)
                    {
                        return new ErrorResult(Messages.CarIsNotAvailable);
                    }
                   
                }
                
            }
            return new SuccessResult();

        }

        
    }
}
