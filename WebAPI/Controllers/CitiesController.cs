using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Business.Abstract;
using CityGuide.API.Models;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public CitiesController(ICityService cityService, IPhotoService photoService ,IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
            _photoService = photoService;
        }

        [HttpGet("getall")]
        
        public IActionResult GetCities()
        { 
            var result =_cityService.GetAll();
            if(result.Success)
            {
                var citiesToReturn = _mapper.Map<List<CityForListDto>>(result.Data);
                return Ok(citiesToReturn);
            }
            return BadRequest(result.Message);
            
        }
        
        [HttpGet("detail")]
        [Authorize()]
        public IActionResult Detail(int cityId)
        {
             var result =_cityService.GetCityById(cityId);
             if(result.Success)
             {
                 var cityToReturn = _mapper.Map<CityDetailDto>(result.Data);
                 return Ok(cityToReturn);
             }
             return BadRequest(result.Message);
        }

        [HttpGet("getPhotosByCity")]
        [Authorize()]
        public IActionResult GetPhotosByCity(int cityId)
        {
            var result = _photoService.GetPhotosByCity(cityId);
            if(result.Success)
             {
                 return Ok(result.Data);
             }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody]City city)
        {
            var result = _cityService.Add(city);
            if(result.Success)
            {
                return Ok(result.Message); 
            }
            return BadRequest();
        }

        [HttpPost("update")]
        [Authorize()]
        public IActionResult Update([FromBody]City city)
        {
            var result =  _cityService.Update(city);
            if(result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);

        }
 
        [HttpPost("delete")]
        [Authorize()]
        public IActionResult Delete([FromBody]City city)
        {
            var cityDb = _cityService.GetCityById(city.Id);

            if(cityDb.Data == null)
            {
                return BadRequest();
            }
            
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            
            if(currentUserId != cityDb.Data.UserId)
            {
                return Unauthorized();
            }

            var result = _cityService.Delete(cityDb.Data);
            if(result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);

        }
        
    }
}