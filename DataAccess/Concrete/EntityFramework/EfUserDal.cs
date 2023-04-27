using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentACarDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }

        public List<UserDto> GetUserDetails()
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from u in context.Users
                             join o in context.UserOperationClaims
                             on u.Id equals o.UserId
                             join cl in context.OperationClaims
                             on o.OperationClaimId equals cl.Id
                             join c in context.Customers
                             on u.Id equals c.UserId
                             select new UserDto
                             {
                                 UserId = u.Id,
                                 ClaimId = cl.Id,
                                 CustomerId = c.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName,
                                 ClaimName = cl.Name,
                                 FindeksPoint = c.FindeksPoint
                             };
                return result.ToList();
            }
        }

        public UserDto GetUserDetailById(int userId)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from u in context.Users.Where(u => u.Id == userId)
                             join o in context.UserOperationClaims
                             on u.Id equals o.UserId
                             join cl in context.OperationClaims
                             on o.OperationClaimId equals cl.Id
                             join c in context.Customers
                             on u.Id equals c.UserId
                             select new UserDto
                             {
                                 UserId = u.Id,
                                 ClaimId = cl.Id,
                                 CustomerId = c.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName,
                                 ClaimName = cl.Name,
                                 FindeksPoint = c.FindeksPoint
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
