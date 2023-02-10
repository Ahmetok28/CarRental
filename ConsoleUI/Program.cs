// See https://aka.ms/new-console-template for more information
using Bussines.Concrate;
using DataAccess.Concrate.EntityFramework;
using DataAccess.Concrate.InMemory;
using Entities.Concrate;

CarManager carManager = new CarManager(new EfCarDal());
BrandManager brandManager = new BrandManager(new EfBrandDal());
UserManager userManager = new UserManager(new EfUserDal());
CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
RentalManager rentalManager= new RentalManager(new EfRentalDal());
//userManager.Add(new User { Id=1,FirstName="Ahmet",LastName="OK",Email="ahmetok2861@gmail.com",Password="12345"});
//userManager.Add(new User { Id=2,FirstName="emre",LastName="OK",Email="emreok2861@gmail.com",Password="12345"});
//userManager.Add(new User { Id=3,FirstName="ali",LastName="OK",Email="ali2861@gmail.com",Password="12345"});
Console.WriteLine("kullanıcılar eklendi");
var resultUser = userManager.GetAll();
if (resultUser.IsSuccess)
{
    foreach (var item in resultUser.Data )
    {
        Console.WriteLine(item.FirstName+" "+item.LastName);
    }
}



//customerManager.Add(new Customer { CustomerId=1,CompanyName="DMR",UserId=1});
//customerManager.Add(new Customer { CustomerId=2,CompanyName="OOK",UserId=2});
Console.WriteLine();
Console.WriteLine("Müşteri Eklendi");
Console.WriteLine();
var resultCustomer = customerManager.GetAll();
if (resultCustomer.IsSuccess)
{
    foreach (var item in resultCustomer.Data)
    {
        Console.WriteLine(item.CompanyName);
    }
}
Console.WriteLine();
//rentalManager.Add(new Rental { Id=1,CarId=1,RentDate=new DateTime(2023,02,11),ReturnDate=new DateTime(2023,05,11)});
//rentalManager.Add(new Rental { Id=2,CarId=4,RentDate=new DateTime(2023,01,21),ReturnDate=new DateTime(2023,12,11)});
rentalManager.Delete(rentalManager.GetById(4).Data);
Console.WriteLine("rental added");
Console.WriteLine();
 var resultRental = rentalManager.GetAll();
if (resultRental.IsSuccess)
{
    foreach (var item in resultRental.Data)
    {
        Console.WriteLine(item.CarId+" Alış Tarihi: "+item.RentDate.ToString()+" Teslim Tarihi: "+item.ReturnDate.ToString());
    }
}

Console.WriteLine("---------------------------");
var resultCarDto = carManager.GetCarDetail();
if (resultCarDto.IsSuccess)
{
    foreach (var item in resultCarDto.Data)
    {
        Console.WriteLine(item.BrandName + " " + item.Name + " " + item.ColorName + " " + item.DailyPrice);
    }
    
}
else
{
    Console.WriteLine(resultCarDto.Message);
}

Console.WriteLine("---------------------------");




