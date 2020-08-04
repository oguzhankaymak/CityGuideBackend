using System.Collections.Generic;
using System.Linq;
using CityGuide.API.Models;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCityDal :EfEntityRepositoryBase<City,DatabaseContext>, ICityDal
    {
        public City GetDetail(int cityId)
        {
            using(var context = new DatabaseContext())
            {
                var result = context.Cities.Include(x=>x.Photos).SingleOrDefault(c => c.Id == cityId);
                return result;
            }

        }

        public List<City> GetAll()
        {
            using(var context = new DatabaseContext())
            {
                var result = context.Cities.Include(x=>x.Photos).ToList();
                return result;
            }

        }
    }
}