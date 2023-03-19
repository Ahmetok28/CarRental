using Business.Abstract;


using Business.ValidationRules.FluentValidation;
using Bussines.BusinessAspects.Autofac;
using Bussines.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }
       // [SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [PerformanceAspect(5)]
        [CacheRemoveAspect("ICarService")]
        public IResult Add(Car car)
        {
            IResult result= BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId),CheckIfBrandLimitExceded());

            if (result!=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            IResult result = BusinessRules.Run(CheckCardIdExist(car.Id));

            if (result != null)
            {
                return result;
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run(CheckCardIdExist(car.Id));

            if (result != null)
            {
                return result;
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByCarId(int carId)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == carId));
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetByCarDetailId(int carId)
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == carId));
        }



        [CacheAspect]
       // [SecuredOperation("admin")]
        public IDataResult<List<Car>> GetAll()
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarByBrand(int brandId)
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c=>c.BrandId==brandId));
            return result;
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarByColor(int colorId)
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId));
            return result;
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
            return result;
        }
        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            if (brandId==1)
            {
                var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
                if (result >= 2)
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
        }
        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckCardIdExist(int carId)
        {
            Car result = _carDal.Get(c => c.Id == carId);
            if (result != null)
            {
                return  new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
