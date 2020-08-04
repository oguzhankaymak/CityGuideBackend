using System.Collections.Generic;
using CityGuide.API.Models;
using Core.DataAccess.Abstract;

namespace DataAccess.Abstract
{
    public interface ICityDal : IEntityRepository<City>
    {
         List<City> GetAll();
         City GetDetail(int cityId);
    }
}