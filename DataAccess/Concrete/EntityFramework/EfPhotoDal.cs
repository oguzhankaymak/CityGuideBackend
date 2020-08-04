using CityGuide.API.Models;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPhotoDal : EfEntityRepositoryBase<Photo, DatabaseContext>, IPhotoDal
    {
        public void AddPhotoForCity(Photo photo)
        {
             using(var context = new DatabaseContext())
            {
                var result = context.Photos.Add(photo);
                context.SaveChanges();
            }
        }
    }
}