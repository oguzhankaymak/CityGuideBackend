using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constans;
using CityGuide.API.Models;
using Core.Entities.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class CityService : ICityService
    {
        private readonly ICityDal _cityDal;
        public CityService(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public IResult Add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<City>> GetAll()
        {
           return new SuccessDataResult<List<City>>( _cityDal.GetAll());
        }

        public IDataResult<City> GetCityById(int cityId)
        {
            return new SuccessDataResult<City>(_cityDal.GetDetail(cityId));
        }
    }
}