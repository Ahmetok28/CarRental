using Core.DataAccess;
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
    public class EfUserDal:EfEntityRepositoryBase<User,RentACarDbContext>, IUserDal
    {
    }
}
