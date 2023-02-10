using Core.DataAccess.EntityFramwork;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,RentACarDbContext>,IRentalDal
    {
    }
}
