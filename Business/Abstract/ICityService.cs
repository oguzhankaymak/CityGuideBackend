using System.Collections.Generic;
using CityGuide.API.Models;
using Core.Entities.Abstract;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICityService
    {
        IDataResult<List<City>> GetAll();
        IDataResult<City> GetCityById(int cityId);
    
        IResult Add(City City);
        IResult Update(City City);
        IResult Delete(City City);


    }
}