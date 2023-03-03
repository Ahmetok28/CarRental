using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join rent in context.Rentals
                             on car.Id equals rent.CarId
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join cust in context.Customers
                             on rent.CustomerId equals cust.CustomerId
                             join user in context.Users
                             on cust.UserId equals user.Id


                             select new RentalDetailDto
                             {
                                 BrandId=brand.Id,
                                 CarId=car.Id,
                                 ColorId=color.Id,
                                 ColorName = color.ColorName,
                                 BrandName = brand.BrandName,
                                 ModelName = car.Name,
                                 UserName = user.FirstName+" "+user.LastName,
                                 RentDate = rent.RentDate,
                                 ReturnDate = rent.ReturnDate

                             };
                return result.ToList();
            }
        }
    }
}
