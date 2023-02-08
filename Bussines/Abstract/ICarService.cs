using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface ICarService
    {
        Car GetById(int id);
        List<Car> GetAll();
        List<CarDetailDto> GetCarDetail();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
