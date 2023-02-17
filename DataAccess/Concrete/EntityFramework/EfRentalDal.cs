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
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             join re in context.Rentals
                             on ca.Id equals re.CarId
                             join co in context.Colors
                             on ca.ColorId equals co.Id
                             select new RentalDetailDto
                             {
                                 CarId = ca.Id,
                                 BrandId = b.Id,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 ModelName = ca.Name,
                                 RentalId = re.Id,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate

                             };
                return result.ToList();
            }
        }
    }
}
