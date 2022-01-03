using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastWebAPI.Models;

namespace WeatherForecastWebAPI.Services
{
    public class WeatherService
    {
        private static IMongoClient client;
        private static IMongoDatabase database;
        private static IMongoCollection<CityWeather> weatherColl;
        public WeatherService()
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("WeatherForecastDB");
            weatherColl = database.GetCollection<CityWeather>("CityWeather");
        }

        public CityWeather GetWeather(string CityName)
        {
            FilterDefinition<CityWeather> filter = Builders<CityWeather>.Filter.Eq(x => x.CityName, CityName);

            return weatherColl.Find(filter).FirstOrDefault();
        }

        //public List<CityWeather> GetCities()
        //{
        //    var builder = new FilterDefinitionBuilder<CityWeather>();
        //    var filter = builder.Empty; // фильтр для выборки всех документов

        //    return weatherColl.Find(filter).ToList();
        //}

        public List<string> GetCities()
        {
            var builder = new FilterDefinitionBuilder<CityWeather>();
            var filter = builder.Empty; // фильтр для выборки всех документов

            return weatherColl.Find(filter).ToList().Select(x => x.CityName).ToList();
        }
    }
}
