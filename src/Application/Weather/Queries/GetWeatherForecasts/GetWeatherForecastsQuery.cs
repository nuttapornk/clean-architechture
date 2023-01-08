using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Areegator.Agent.Application.Weather.Queries.GetWeatherForecasts;

public class GetWeatherForecastsQuery : IRequest<IEnumerable<WeatherForecastsResponse>>
{
    public class GetWeatherForecastsHandler : RequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecastsResponse>>
    {
        private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        protected override IEnumerable<WeatherForecastsResponse> Handle(GetWeatherForecastsQuery request)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(a => new WeatherForecastsResponse
            {
                Date = DateTime.Now.AddDays(a),
                TemperatureC = rng.Next(-20, 50),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
    }
}
