using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WeatherForecastWebAPI
{
    public class MongoWeatherDBContext : IMongoWeatherDBContext
    {
        private IMongoDatabase db { get; set; }
        private MongoClient mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoWeatherDBContext (IOptions<Mongosettings> configuration)
        {
            mongoClient = new MongoClient(configuration.Value.Connection);
            db = mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return db.GetCollection<T>(name);
        }
    }
}
