using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using WeatherForecastModels;
using WeatherForecastWebAPI;
using WeatherForecastWebAPI.Controllers;

namespace WeatherForecastWebAPITests
{
    public class ControllerTests
    {
        private Mock<IMongoCollection<CityWeather>> mockCollection;
        private Mock<IMongoWeatherDBContext> mockContext;
        private List<CityWeather> cityWeatherlist;
        private CityWeather cityWeatherTest;
        public ControllerTests()
        {
            cityWeatherTest = new CityWeather()
            {
                //id = new MongoDB.Bson.ObjectId("123"),
                CityName = "MyCity",
                Date = DateTime.Now.Date,
                WeatherForecast = new Weather[2]
            };

            cityWeatherTest.WeatherForecast[0] = new Weather()
            {
                Cloudiness = "pasmurno",
                Humidity = 99,
                Geomagnetic = 1,
                Precipitation = 1,
                PressureMax = 100,
                PressureMin = 99,
                Radiation = 1,
                TempretureMax = 1,
                TempretureMin = 0,
                Wind = new Wind()
                {
                    AvgSpeed = 1,
                    GustSpeed = 2,
                    Direction = "A"
                }
            };

            cityWeatherTest.WeatherForecast[1] = new Weather()
            {
                Cloudiness = "horosho",
                Humidity = 100,
                Geomagnetic = 2,
                Precipitation = 2,
                PressureMax = 101,
                PressureMin = 98,
                Radiation = 2,
                TempretureMax = 2,
                TempretureMin = 1,
                Wind = new Wind()
                {
                    AvgSpeed = 2,
                    GustSpeed = 3,
                    Direction = "B"
                }
            };

            mockCollection = new Mock<IMongoCollection<CityWeather>>();
            mockCollection.Object.InsertOne(cityWeatherTest);
            mockContext = new Mock<IMongoWeatherDBContext>();
            cityWeatherlist = new List<CityWeather>();
            cityWeatherlist.Add(cityWeatherTest);
        }

        [Test]
        public void GeCitiesOk()
        {
            // Arrange
            Mock<IAsyncCursor<CityWeather>> weatherCursor = new Mock<IAsyncCursor<CityWeather>>();
            weatherCursor.Setup(x => x.Current).Returns(cityWeatherlist);
            weatherCursor.SetupSequence(x => x.MoveNext(It.IsAny<CancellationToken>()))
                .Returns(true)
                .Returns(false);

            mockCollection.Setup(x => x.FindSync(It.IsAny<FilterDefinition<CityWeather>>(),
                It.IsAny<FindOptions<CityWeather, CityWeather>>(),
                It.IsAny<CancellationToken>())).Returns(weatherCursor.Object);

            mockContext.Setup(c => c.GetCollection<CityWeather>(typeof(CityWeather).Name)).Returns(mockCollection.Object);

            // Act
            var weatherController = new WeatherCitiesController(mockContext.Object);
            var actionResult = weatherController.Get();
            var result = actionResult.Result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var resultList = result.Value as List<string>;

            Assert.AreEqual(resultList.Count, cityWeatherlist.Count);
            foreach (var cityWeather in resultList)
            {
                Assert.NotNull(cityWeather);
                Assert.AreEqual(cityWeather, cityWeatherTest.CityName);
            }
        }
    }
}