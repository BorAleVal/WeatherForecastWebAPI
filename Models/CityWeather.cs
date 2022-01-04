using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace WeatherForecastWebAPI.Models
{
    public class CityWeather
    {
        // TODO : Вероятно нужно вынести в отдельный проект, что бы использовать во всех решениях.
        public string CityName { get; set; }
        public Weather Weather { get; set; } = new Weather();
        public DateTime Date { get; set; }

        [JsonIgnore]
        [BsonId]
        public ObjectId? id { get { return ObjectId.GenerateNewId(); } set { } }
    }
}
