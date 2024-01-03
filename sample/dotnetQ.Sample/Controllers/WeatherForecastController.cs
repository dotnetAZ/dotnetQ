using dotnetQ.Core.Entities;
using dotnetQ.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetQ.Sample.Controllers
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
        private readonly IQManager iqManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IQManager iqManager)
        {
            _logger = logger;
            this.iqManager = iqManager;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            iqManager.AddItem(new Item()
            {
                TypeId = 
            });
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
