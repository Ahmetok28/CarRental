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
    public class ColorDal
    {
        public void Add(Color entity)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var entityToAdd = context.Entry(entity);
                entityToAdd.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var entityToDelete = context.Entry(entity);
                entityToDelete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }

        public Color GetByFilter(Expression<Func<Color, bool>> filter)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }
        public void Update(Color entity)
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
