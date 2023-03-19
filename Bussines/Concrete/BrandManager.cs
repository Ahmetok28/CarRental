using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Bussines.BusinessAspects.Autofac;
using Bussines.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExist(brand.BrandName));
            if (result!=null)
            {
                return new ErrorResult();
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }

        public IResult Delete(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckBrandExist(brand.Id));
            if (result!=null)
            {
                return new ErrorResult();
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExistDiffrentId(brand.BrandName,brand.Id),CheckBrandExist(brand.Id));
            if (result != null)
            {
                return result;
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }

        //[SecuredOperation("")]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetByBrandId(int brandId)
        {
            IResult result = BusinessRules.Run(CheckBrandExist(brandId));
            if (result!=null)
            {
                return new ErrorDataResult<Brand>();
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId));
        }

        private IResult CheckIfBrandNameExistDiffrentId(string brandName , int brandId)
        {
            var result = _brandDal.GetAll(b => b.BrandName == brandName && b.Id != brandId).Any();
            if (result==true)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult CheckIfBrandNameExist(string brandName)
        {
            var result = _brandDal.GetAll(b => b.BrandName == brandName ).Any();
            if (result == true)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExist);
            }
            return new SuccessResult();
        }
        private IResult CheckBrandExist(int brandId)
        {
            var result = _brandDal.GetAll(b => b.Id == brandId).Any();
            if (!result)
            {
                return new ErrorResult("marka bulunamadı.");
            }
            return new SuccessResult();
        }
    }
}
