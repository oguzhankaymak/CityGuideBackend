using CityGuide.API.Models;
using Core.DataAccess.Abstract;

namespace DataAccess.Abstract
{
    public interface IPhotoDal: IEntityRepository<Photo>
    {
        void AddPhotoForCity(Photo photo);
    }
}