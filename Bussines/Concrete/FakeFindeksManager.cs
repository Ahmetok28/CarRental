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
    public class FakeFindeksManager : IFindeksService
    {
        //private readonly IFindeksDal _findeksDal;

        public FakeFindeksManager()
        {
            
        }

        //[SecuredOperation("user")]
        //public IDataResult<Findeks> GetById(int id)
        //{
        //    return new SuccessDataResult<Findeks>(_findeksDal.Get(f => f.Id == id));
        //}

        //[SecuredOperation("user")]
        //public IDataResult<Findeks> GetByCustomerId(int customerId)
        //{
        //    var findeks = _findeksDal.Get(f => f.CustomerId == customerId);
        //    if (findeks == null) return new ErrorDataResult<Findeks>(Messages.NotFound);

        //    return new SuccessDataResult<Findeks>(findeks);
        //}

        //[SecuredOperation("user")]
        //public IDataResult<List<Findeks>> GetAll()
        //{
        //    return new SuccessDataResult<List<Findeks>>(_findeksDal.GetAll());
        //}

        //[SecuredOperation("user")]
        //public IResult Add(Findeks findeks)
        //{
        //    var newFindeks = CalculateFindeksScore(findeks).Data;
        //    _findeksDal.Add(newFindeks);

        //    return new SuccessResult(Messages.SuccesfullyAdded);
        //}

        //[SecuredOperation("moderator,admin")]
        //public IResult Update(Findeks findeks)
        //{
        //    var newFindeksScore = CalculateFindeksScore().Data;
        //    findeks.Score = newFindeksScore;
        //    _findeksDal.Update(findeks);

        //    return new SuccessResult(Messages.SuccesfullyUpdated);
        //}

        //[SecuredOperation("moderator,admin")]
        //public IResult Delete(Findeks findeks)
        //{
        //    _findeksDal.Delete(findeks);

        //    return new SuccessResult(Messages.SuccesfullyDeleted);
        //}

        public IDataResult<int> CalculateFindeksScore() // Fake
        {
            int score = new Random().Next(800, 1901);

            return new SuccessDataResult<int>(score);
        }
    }
}
