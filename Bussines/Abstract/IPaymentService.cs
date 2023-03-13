using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface IPaymentService
    {
        IDataResult<List<Payment>> GetAll();
        IResult Pay(Payment entity);
        IResult Add(Payment entity);
        IResult Delete(Payment entity);
        IResult Update(Payment entity);
    }
}
