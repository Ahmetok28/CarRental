using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class RentACarDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MACHINA;Database=ReCapProject;Trusted_Connection=true;TrustServerCertificate=True");
        }

        DbSet<Car> Cars { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Color> Colors { get; set; }
    }
}
