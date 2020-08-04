using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Helpers;

namespace WebApi.Services.Concrete
{
   public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserDal _userDal;

        public UserService(IOptions<AppSettings> appSettings, IUserDal userDal)
        {
            _appSettings = appSettings.Value;
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
           _userDal.Add(user);
           return new SuccessResult(Messages.Added);
        }
        public IDataResult<IEnumerable<User>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<User>>(_userDal.GetList());

        }

        public IDataResult<User> GetByUsername(string userName)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Username == userName));
        }
        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IResult Register(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}