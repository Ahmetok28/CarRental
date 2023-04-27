using Business.Constants;
using Bussines.Abstract;
using Bussines.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class ProfilePhotoManager : IProfilePhotoService
    {

        IProfilePhotoDal _profilePhotoDal;
        IFileHelper _fileHelper;

        public ProfilePhotoManager(IProfilePhotoDal profilePhotoDal, IFileHelper fileHelper)
        {
            _profilePhotoDal = profilePhotoDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, ProfilePhoto profilePhoto)
        {

            profilePhoto.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            profilePhoto.Date = DateTime.Now;
            _profilePhotoDal.Add(profilePhoto);
            return new SuccessResult("Resim başarıyla yüklendi");
        }
        public IResult Delete(ProfilePhoto profilePhoto)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + profilePhoto.ImagePath);
            _profilePhotoDal.Delete(profilePhoto);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

        public IDataResult<List<ProfilePhoto>> GetAll()
        {
            return new SuccessDataResult<List<ProfilePhoto>>(_profilePhotoDal.GetAll());
        }

        public IDataResult<ProfilePhoto> GetById(int id)
        {
            return new SuccessDataResult<ProfilePhoto>(_profilePhotoDal.Get(p => p.Id == id));
        }

        public IDataResult<List<ProfilePhoto>> GetByUserId(int id)
        {
            var result = BusinessRules.Run(CheckIfProfilePhotoNull(id));
            if (result!=null)
            {
                return new ErrorDataResult<List<ProfilePhoto>>(GetDefaultImage(id).Data);
            }
            return new SuccessDataResult<List<ProfilePhoto>>(_profilePhotoDal.GetAll(p=>p.Id==id));
        }

        public IResult Update(IFormFile formFile, ProfilePhoto profilePhoto)
        {
            profilePhoto.ImagePath = _fileHelper.Update(formFile, PathConstants.ProfilePhotoPath + profilePhoto.ImagePath, PathConstants.ProfilePhotoPath);
            _profilePhotoDal.Update(profilePhoto);
            return new SuccessResult();
        }
        private IDataResult<List<ProfilePhoto>> GetDefaultImage(int imageId)
        {

            List<ProfilePhoto> profilePhoto = new List<ProfilePhoto>();
            profilePhoto.Add(new ProfilePhoto { Id = imageId, Date = DateTime.Now, ImagePath = "default.jpg" });
            return new SuccessDataResult<List<ProfilePhoto>>(profilePhoto);
        }

        private IResult CheckIfProfilePhotoNull(int id)
        {
            var result = _profilePhotoDal.GetAll(p=>p.Id == id).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
