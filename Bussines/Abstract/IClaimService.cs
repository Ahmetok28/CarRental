using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface IClaimService
    {
        IDataResult<List<UserOperationClaim>> GetAll();
        IDataResult<List<UserOperationClaim>> GetByClaimId(int id);
        IDataResult<List<UserOperationClaim>> GetByUserId(int id);
        IResult Add(UserOperationClaim claim);
        IResult AddUser(User user);
        IResult Update(UserOperationClaim claim);
        IResult Delete(UserOperationClaim claim);
        IResult DeleteUser(User user);

    }
}
