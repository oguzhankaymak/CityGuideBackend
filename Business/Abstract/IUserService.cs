using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {

        IResult Add(User user);

        IDataResult<User> GetByUsername(string userName);
        IDataResult<User> GetByEmail(string email);

        IDataResult<List<OperationClaim>> GetClaims(User user);

        IDataResult<IEnumerable<User>> GetAll();
    }
}