// See https://aka.ms/new-console-template for more information
using Bussines.Concrate;
using DataAccess.Concrate.InMemory;

CarManager carManager = new CarManager(new InMemoryCarDal());
foreach (var item in carManager.GetAll())
{
    Console.WriteLine(item.CarName);
}
