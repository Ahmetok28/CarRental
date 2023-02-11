using Bussines.Abstract;
using Bussines.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;

// Add services to the container.

service.AddControllers();
service.AddSingleton<ICarService, CarManager>();
service.AddSingleton<ICarDal, EfCarDal>();

service.AddSingleton<IBrandService, BrandManager>();
service.AddSingleton<IBrandDal, EfBrandDal>();

service.AddSingleton<IColorService, ColorManager>();
service.AddSingleton<IColorDal, EfColorDal>();

service.AddSingleton<IUserService, UserManager>();
service.AddSingleton<IUserDal, EfUserDal>();

service.AddSingleton<ICustomerService, CustomerManager>();
service.AddSingleton<ICustomerDal, EfCustomerDal>();

service.AddSingleton<IRentalService, RentalManager>();
service.AddSingleton<IRentalDal, EfRentalDal>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
