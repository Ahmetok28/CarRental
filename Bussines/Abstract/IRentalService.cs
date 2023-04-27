using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IResult CheckCarStatus(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetRentalByCarId(int CarId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<RentalDetailDto>> GetByCustomerId(int rentalId);
        IDataResult<Rental> GetByCarId(int carId);
        

    }
}
