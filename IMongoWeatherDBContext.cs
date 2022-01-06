using MongoDB.Driver;

namespace WeatherForecastWebAPI
{
    public interface IMongoWeatherDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
