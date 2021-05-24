using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BannedApiAnalyzers.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random(1);
            var weatherForecast = new WeatherForecast(); // No reason to initialize the object here and set the properties later
            weatherForecast.Date = DateTime.Now;
            weatherForecast.TemperatureC = rng.Next(-20, 55);
            weatherForecast.Summary = Summaries[rng.Next(Summaries.Length)];
            Activator.CreateInstance<WeatherForecast>(); // Reflection in .NET is very powerful, but expensive
            _logger.LogInformation($"Temperature for date {weatherForecast.Date} is {weatherForecast.TemperatureF}"); // Deprecated use of property
            return new []{ weatherForecast };
        }
    }
}
