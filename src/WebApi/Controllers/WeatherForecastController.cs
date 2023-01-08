using Microsoft.AspNetCore.Mvc;
using Areegator.Agent.Application.Weather.Queries.GetWeatherForecasts;

namespace Areegator.Agent.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ApiControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecastsResponse>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
