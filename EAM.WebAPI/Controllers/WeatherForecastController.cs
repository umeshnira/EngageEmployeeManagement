using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAM.Application;
using EAM.Application.Services;
using EAM.Data;
using EAM.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EAM.WebAPI.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBService<UserService> _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBService<UserService> service)
        {
            _logger = logger;
            _service = service;
            
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var a = _service.provider.Test("abc", "abc");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = a //Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
