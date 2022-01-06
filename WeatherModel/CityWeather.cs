using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace WeatherForecastModels
{
    public class CityWeather
    {
        public string CityName { get; set; }
        public Weather[] WeatherForecast { get; set; }
        public DateTime Date { get; set; }

        [JsonIgnore]
        [BsonId]
        public ObjectId? id { get { return ObjectId.GenerateNewId(); } set { } }
    }
}
