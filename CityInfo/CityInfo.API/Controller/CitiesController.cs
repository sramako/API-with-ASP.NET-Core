using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controller
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;

        /*
[HttpGet]
public JsonResult GetCities()
{
return new JsonResult(CitiesDataStore.Current.Cities);
}
[HttpGet("{id}")]
public JsonResult GetCity(int id)
{
return new JsonResult(
CitiesDataStore.Current.Cities.FirstOrDefault(o => o.Id == id));    
}
*/
        [HttpGet]
        public IActionResult GetCities()
        {
            //return Ok(CitiesDataStore.Current.Cities);
            var cityEntities = _cityInfoRepository.GetCities();

            var results = new List<CityWithoutPointsOfInterestDto>();

            foreach(var cityEntity in cityEntities)
            {
                results.Add(new CityWithoutPointsOfInterestDto
                {
                    Id = cityEntity.Id,
                    Description = cityEntity.Description,
                    Name = cityEntity.Name
                });
            }
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var toReturn = CitiesDataStore.Current.Cities.FirstOrDefault(o => o.Id == id);
            if(toReturn == null)
            {
                return NotFound();
            }
            return Ok(toReturn);
        }

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
        }
    }
}
