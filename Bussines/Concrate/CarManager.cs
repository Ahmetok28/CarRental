using Bussines.Abstract;
using Bussines.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Name.Length<2)
            {
                return new ErrorResult(Messages.InvalidName);
            }
            
            _carDal.Add(car);
            return new SuccessResult(Messages.SuccesfullyAdded);
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccesDataResult<List<Car>>( _carDal.GetAll(c=>c.BrandId==7));
        }

        public IDataResult<Car> GetById(int id)
        {
           return new SuccesDataResult<Car>( _carDal.Get(b=>b.Id==id));

            
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {            
            return new SuccesDataResult<List<CarDetailDto>>( _carDal.GetCarDetail());
        }

        public IResult Update(Car car)
        {
            if (car.Name.Length < 2)
            {
              return new ErrorResult(Messages.InvalidName);
            }
            
            _carDal.Update(car);
            return new SuccessResult(Messages.SuccesfullyUpdated);
            
        }
    }
}
