// See https://aka.ms/new-console-template for more information
using Bussines.Concrate;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;
using Entities.Concrate;

CarManager carManager = new CarManager(new CarDal());
BrandManager brandManager = new BrandManager(new BrandDal());


Console.WriteLine(carManager.GetById(1).Name);
Console.WriteLine("---------------------------");
foreach (var item in brandManager.GetAll())
{
    Console.WriteLine(item.BrandName);
}
Console.WriteLine("---------------------------");


