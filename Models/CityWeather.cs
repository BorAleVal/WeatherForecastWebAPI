using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WeatherForecastWebAPI.Models
{
    public class CityWeather
    {
        public string CityName { get; set; }
        public Weather Weather { get; set; } = new Weather();
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        public ObjectId? id { get { return ObjectId.GenerateNewId(); } set { } }
    }
}
