using System;

namespace VulnDotNetCore.Models
{
    public class CityWeather
    {
        public Guid ID { get; set; }
        public string CityName { get; set; }
        public decimal TemperatureC { get; set; }
        public string Forecast { get; set; }
    }
}