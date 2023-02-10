using Core.DataAccess.EntityFramwork;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 BrandName = b.BrandName,
                                 ColorName=co.ColorName,
                                 DailyPrice=c.DailyPrice
                                 
                             };
                return result.ToList();
            }
        }
    }
}
