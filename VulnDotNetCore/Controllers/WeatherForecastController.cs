using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;
using VulnDotNetCore.Data;
using VulnDotNetCore.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace VulnDotNetCore.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;
        private readonly ILogger _logger;

        public WeatherForecastController(ApplicationDbContext ctx, ILogger logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        [HttpGet]
        public Task<List<CityWeather>> Get(string query)
        {
            _logger.Debug($"User query string: {query}");

            return Easy(query);
            //return Medium(query);
            //return Hard(query);
        }

        private Task<List<CityWeather>> Easy(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return _ctx.CityWeather.ToListAsync();
            }
            else
            {
                var sql = $"SELECT * From {nameof(CityWeather)} Where {nameof(CityWeather.CityName)} like '%{query}%'";

                return _ctx.CityWeather.FromSqlRaw(sql).ToListAsync();
            }
        }

        private Task<List<CityWeather>> Medium(string query)
        {
            return Easy(FilterChars(query));
        }

        private Task<List<CityWeather>> Hard(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return _ctx.CityWeather.ToListAsync();
            }
            else
            {
                return _ctx.CityWeather.Where(c => c.CityName.Contains(query)).ToListAsync();
            }
        }

        private string FilterChars(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return query;

            var filtered = query.Replace(" ", "");

            _logger.Debug($"Filtered query string: {filtered}");

            return filtered;
        }
    }
}