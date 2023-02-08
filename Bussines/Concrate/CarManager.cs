using Bussines.Abstract;
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

        public void Add(Car car)
        {
            if (car.Name.Length<2)
            {
                new InvalidOperationException("Araç ismi minimum 2 karakter olmalıdır");
            }
            else
            {
                _carDal.Add(car);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll(c=>c.BrandId==7);
        }

        public Car GetById(int id)
        {
           return _carDal.Get(b=>b.Id==id);

            
        }

        public List<CarDetailDto> GetCarDetail()
        {
            return _carDal.GetCarDetail();
        }

        public void Update(Car car)
        {
            if (car.Name.Length < 2)
            {
                new InvalidOperationException("Araç ismi minimum 2 karakter olmalıdır");
            }
            else
            {
                _carDal.Update(car);
            }
        }
    }
}
