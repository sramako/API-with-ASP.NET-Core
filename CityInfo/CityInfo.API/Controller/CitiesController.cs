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
            return Ok(CitiesDataStore.Current.Cities);
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
    }
}
