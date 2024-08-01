using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningApp.Controllers.v2;

[ApiController]
[Route("api/v{version:apiVersion}[controller]")]
[ApiVersion("2.0", Deprecated = true)]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [ApiVersion("2.0")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = "The weather is nice and cool - v2.0"
        })
        .ToArray();
    }

    [HttpGet(Name = "GetWeatherForecastV21")]
    [ApiVersion("2.1")]
    public IEnumerable<WeatherForecast> GetV21()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = "The weather is hot - v2.1"
        })
        .ToArray();
    }
}
