// See https://aka.ms/new-console-template for more information
using Bussines.Concrate;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;
using Entities.Concrate;

CarManager carManager = new CarManager(new CarDal());
BrandManager brandManager = new BrandManager(new BrandDal());



Console.WriteLine("---------------------------");
var result = carManager.GetCarDetail();
if (result.IsSuccess)
{
    foreach (var item in result.Data)
    {
        Console.WriteLine(item.BrandName + " " + item.Name + " " + item.ColorName + " " + item.DailyPrice);
    }
}
else
{
    Console.WriteLine(result.Message);
}

Console.WriteLine("---------------------------");


