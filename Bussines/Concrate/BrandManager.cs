using Bussines.Abstract;
using Bussines.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrate
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.InvalidName);
            }
            
            _brandDal.Add(brand);
            return new SuccessResult(Messages.SuccesfullyAdded);


        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccesDataResult<List<Brand>>( _brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int id)
        {
            
            return new SuccesDataResult<Brand> (_brandDal.Get(b=>b.Id == id));
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.InvalidName);
            }
            
            _brandDal.Update(brand);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
