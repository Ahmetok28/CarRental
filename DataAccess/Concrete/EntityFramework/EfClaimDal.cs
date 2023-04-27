using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfClaimDal : EfEntityRepositoryBase<UserOperationClaim, RentACarDbContext>, IClaimDal
    {
    }
}
