using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Areegator.Agent.Application.Weather.Queries.GetWeatherForecasts
{
    public class WeatherForecastsResponse
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatireF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
    }
}