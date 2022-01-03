using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecastWebAPI.Models;
using WeatherForecastWebAPI.Services;

namespace WeatherForecastWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherCitiesController : ControllerBase
    {
        private readonly WeatherService weatherService;

        public WeatherCitiesController(WeatherService context)
        {
            weatherService = context;
        }

        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return weatherService.GetCities();
        }

        [HttpGet("{City}")]
        public ActionResult<CityWeather> Get(string City)
        {
            return weatherService.GetWeather(City);
        }

        //[HttpGet]
        //public ActionResult<List<CityWeather>> Get()
        //{
        //    return weatherService.GetCities();
        //}
    }
}
