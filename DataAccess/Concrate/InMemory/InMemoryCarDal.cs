using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            { 
                new Car{ Id = 1,BrandId=1,ColorId=1,CarName="Q8",DailyPrice=845000,Description="SUV",ModelYear=new DateTime(2017)},
                new Car{ Id = 2,BrandId=2,ColorId=1,CarName="XC 90",DailyPrice=1245000,Description="SUV",ModelYear=new DateTime(2022)},
                new Car{ Id = 3,BrandId=1,ColorId=2,CarName="A8",DailyPrice=645000,Description="SEDAN",ModelYear=new DateTime(2019)},
                new Car{ Id = 4,BrandId=2,ColorId=3,CarName="S90",DailyPrice=345000,Description="SEDAN",ModelYear=new DateTime(2015)},
                new Car{ Id = 5,BrandId=3,ColorId=3,CarName="F-150",DailyPrice=2145000,Description="PICKUP",ModelYear=new DateTime(2019)},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete=_cars.SingleOrDefault(c=>c.Id== car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
            
        }

        public void Update(Car car)
        {
            var carToUpdate=_cars.SingleOrDefault(c=>c.Id== car.Id);
            carToUpdate.Description=car.Description;
            carToUpdate.ModelYear=car.ModelYear;
            carToUpdate.BrandId=car.BrandId;
            carToUpdate.ColorId=car.ColorId;
            carToUpdate.DailyPrice=car.DailyPrice;
            carToUpdate.CarName=car.CarName;
        }
    }
}
