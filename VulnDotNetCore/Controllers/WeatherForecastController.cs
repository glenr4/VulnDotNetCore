using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VulnDotNetCore.Data;
using VulnDotNetCore.Models;

namespace VulnDotNetCore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _ctx;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        public Task<List<CityWeather>> Get(string query)
        {
            if (String.IsNullOrWhiteSpace(query))
            {
                return _ctx.CityWeather.ToListAsync();
            }
            else
            {
                var sql = $"SELECT * From {nameof(CityWeather)} Where {nameof(CityWeather.CityName)} = '{query}'";

                return _ctx.CityWeather.FromSqlRaw(sql).ToListAsync();
            }
        }
    }
}