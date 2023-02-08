using Core.DataAccess.EntityFramwork;
using DataAccess.Abstract;
using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class ColorDal:EfEntityRepositoryBase<Color, RentACarDbContext> ,IColorDal
    {
       
    }
}
