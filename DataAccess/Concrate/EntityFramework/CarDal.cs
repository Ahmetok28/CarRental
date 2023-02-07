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
    public class CarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var entityToAdd = context.Entry(entity);
                entityToAdd.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var entityToDelete = context.Entry(entity);
                entityToDelete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                return filter == null ? context.Set<Car>().ToList(): context.Set<Car>().Where(filter).ToList();
               
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }
        public void Update(Car entity)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var entityToUpdate = context.Entry(entity);
                entityToUpdate.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
