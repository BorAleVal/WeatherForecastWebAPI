using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastModels;

namespace WeatherForecastWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherCitiesController : ControllerBase
    {
        private readonly IMongoWeatherDBContext context;
        protected IMongoCollection<CityWeather> dbCollection;

        public WeatherCitiesController(IMongoWeatherDBContext context)
        {
            this.context = context;
            dbCollection = this.context.GetCollection<CityWeather>(typeof(CityWeather).Name);
        }

        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            var builder = new FilterDefinitionBuilder<CityWeather>();
            // фильтр для выборки всех документов
            var filter = builder.Empty;
            var cities = dbCollection.Find(filter).ToList().Select(x => x.CityName).ToList();
            return Ok(cities);
        }

        [HttpGet("{CityName}")]
        public ActionResult<CityWeather> Get(string CityName)
        {
            FilterDefinition<CityWeather> filter = Builders<CityWeather>.Filter.Eq(x => x.CityName, CityName);
            var cityWeather = dbCollection.Find(filter).FirstOrDefault();
            return Ok(cityWeather);
        }
    }
}
