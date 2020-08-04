using System.Collections.Generic;
using CityGuide.API.Models;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        IDataResult<List<Photo>> GetPhotosByCity(int cityId);

        IDataResult<Photo> GetPhoto(int id);

        IResult AddPhotoForCity(Photo photo);
    }
}