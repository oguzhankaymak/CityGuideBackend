using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Business.Abstract;
using CityGuide.API.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
     [Route("api/cities/{cityId}/photos")]
    public class PhotosController : Controller
    {
        private IPhotoService _photoService;
        private ICityService _cityService;
        private IMapper _mapper;

        private IOptions<CloudinarySettings> _cloudinarySettings;

        private Cloudinary _cloudinary;

        public PhotosController(IPhotoService photoService,ICityService cityService ,IMapper mapper, IOptions<CloudinarySettings> cloudinarySettings)
        {
            _photoService = photoService;
            _cityService = cityService;
            _mapper = mapper;
            _cloudinarySettings = cloudinarySettings; 

            // For cloudinary
            Account account = new Account(
                _cloudinarySettings.Value.CloudName,
                _cloudinarySettings.Value.ApiKey,
                _cloudinarySettings.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }
    

        [HttpPost("addPhoto")]
        public IActionResult AddPhotoForCity(int cityId,[FromForm]PhotoForCreationDto photoForCreationDto)
        {
            var city = _cityService.GetCityById(cityId).Data;
            if(city == null)
            {
                return BadRequest("Could not find city");
            }
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if(currentUserId != city.UserId)
            {
                return Unauthorized();
            }

            var file =photoForCreationDto.Files;
            try
            {
                var uploadResult = new ImageUploadResult();
                if(file.Length > 0)
                {
                    using(var stream = file.OpenReadStream())
                    {
                        var uploadParam = new ImageUploadParams
                        {
                            File = new FileDescription(file.Name,stream)
                        };

                        uploadResult = _cloudinary.Upload(uploadParam);
                        

                    };

                    photoForCreationDto.Url = uploadResult.Url.ToString();
                    photoForCreationDto.PublicId = uploadResult.PublicId;

                    var photo = _mapper.Map<Photo>(photoForCreationDto);
                    photo.CityId = city.Id;

                    if(!city.Photos.Any(p => p.IsMain))
                    {
                        photo.IsMain = true;
                    }
                    
                    var photoDbResult = _photoService.AddPhotoForCity(photo);

                    if(photoDbResult.Success)
                    {
                        var photoToReturn = _mapper.Map<PhotoForReturnDto>(photo);
                        return Ok(photoToReturn);
                    }
                    return BadRequest("Could not add the photo");
                }
                
                
            }
            
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

            return BadRequest("Failed");
        }
            

        [HttpGet("{id}", Name="GetPhoto")]
        public IActionResult GetPhoto(int id)
        {
            var result = _photoService.GetPhoto(id);
            if(result.Success)
            {
                var photo = _mapper.Map<PhotoForReturnDto>(result.Data);
                return Ok(photo);
            }
            return BadRequest(result.Message);
            
        }
    }
}
