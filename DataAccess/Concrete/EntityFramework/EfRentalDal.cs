using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from rent in context.Rentals
                             
                             join car in context.Cars
                             on rent.CarId equals car.Id

                             join brand in context.Brands
                             on car.BrandId equals brand.Id

                             join color in context.Colors
                             on car.ColorId equals color.Id

                             join cust in context.Customers
                             on rent.CustomerId equals cust.CustomerId

                             join user in context.Users
                             on cust.UserId equals user.Id


                             select new RentalDetailDto
                             {
                                 RentalId=rent.Id,
                                 CustomerId=rent.CustomerId,
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
                return filter == null ? result.ToList()
                                      : result.Where(filter).ToList(); ;
            }
        }

        public bool CheckCarStatus(int carId, DateTime rentDate, DateTime returnDate)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                bool checkReturnDateIsNull = context.Set<Rental>().Any(p => p.CarId == carId && p.ReturnDate == null);
                bool isValidRentDate = context.Set<Rental>()
                    .Any(r => r.CarId == carId && (
                            (rentDate >= r.RentDate && rentDate <= r.ReturnDate) ||
                            (returnDate >= r.RentDate && returnDate <= r.ReturnDate) ||
                            (r.RentDate >= rentDate && r.RentDate <= returnDate)
                            )
                    );

                if ((!checkReturnDateIsNull) && (!isValidRentDate))
                {
                    return true;
                }

                return false;
            }
        }
    }
}
