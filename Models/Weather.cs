using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastWebAPI.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }
        public int[] Tempreture_min { get; set; }
        public int[] Tempreture_max { get; set; }
        public int[] PressureMin { get; set; }
        public int[] PressureMax { get; set; }
        public int[] Humidity { get; set; }
        public int[] Radiation { get; set; }
        public int[] Geomagnetic { get; set; }
        public string[] Cloudiness { get; set; }
        public Wind Wind { get; set; } = new Wind();
        public double[] Precipitation { get; set; }
    }
}
