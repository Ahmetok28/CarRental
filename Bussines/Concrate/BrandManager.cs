using Bussines.Abstract;
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

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                new InvalidOperationException("Marka ismi 2 karkterden büyük olmalı");
            }
            else
            {
                _brandDal.Add(brand);
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            
            return _brandDal.Get(b=>b.Id == id);
        }

        public void Update(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                new InvalidOperationException("Marka ismi 2 karkterden büyük olmalı");
            }
            else
            {
                _brandDal.Update(brand);
            }
        }
    }
}
