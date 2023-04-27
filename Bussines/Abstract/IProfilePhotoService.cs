using Core.Entities.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface IProfilePhotoService
    {
        IResult Add(IFormFile formFile, ProfilePhoto profilePhoto);
        IResult Update(IFormFile formFile, ProfilePhoto profilePhoto);
        IResult Delete(ProfilePhoto profilePhoto);
        IDataResult<List<ProfilePhoto>> GetAll();
        IDataResult<ProfilePhoto> GetById(int id);
        IDataResult<List<ProfilePhoto>> GetByUserId(int id);
    }
}
