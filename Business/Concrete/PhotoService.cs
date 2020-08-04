using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constans;
using CityGuide.API.Models;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoDal _photoDal;
        public PhotoService(IPhotoDal photoDal)
        {
            _photoDal = photoDal;
        }
        public IDataResult<Photo> GetPhoto(int id)
        {
            return new SuccessDataResult<Photo>(_photoDal.Get(p=> p.Id == id));
        }

        public IDataResult<List<Photo>> GetPhotosByCity(int cityId)
        {
            return new SuccessDataResult<List<Photo>>(_photoDal.GetList(p => p.CityId == cityId));
        }

        public IResult AddPhotoForCity(Photo photo)
        {
            _photoDal.AddPhotoForCity(photo);
            return new SuccessResult(Messages.Added);
        }
    }
}