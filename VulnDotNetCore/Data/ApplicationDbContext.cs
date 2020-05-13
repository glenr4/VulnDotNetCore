using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using VulnDotNetCore.Models;

namespace VulnDotNetCore.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<CityWeather> CityWeather { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Test>().ToTable(nameof(Test));

            builder.Entity<CityWeather>().ToTable(nameof(CityWeather));

            // Data seeding - run migrations to execute
            SeedCityWeather(builder);
        }

        private void SeedCityWeather(ModelBuilder builder)
        {
            builder.Entity<CityWeather>().HasData(new CityWeather { ID = Guid.NewGuid(), CityName = "Melbourne", TemperatureC = 12.0m, Forecast = "Grey and cold" });
            builder.Entity<CityWeather>().HasData(new CityWeather { ID = Guid.NewGuid(), CityName = "Sydney", TemperatureC = 20.1m, Forecast = "Warm" });
            builder.Entity<CityWeather>().HasData(new CityWeather { ID = Guid.NewGuid(), CityName = "Brisbane", TemperatureC = 25, Forecast = "Sunny" });
            builder.Entity<CityWeather>().HasData(new CityWeather { ID = Guid.NewGuid(), CityName = "Adelaide", TemperatureC = 18, Forecast = "Warm" });
            builder.Entity<CityWeather>().HasData(new CityWeather { ID = Guid.NewGuid(), CityName = "Perth", TemperatureC = 28, Forecast = "Sunny and windy" });
            builder.Entity<CityWeather>().HasData(new CityWeather { ID = Guid.NewGuid(), CityName = "Hobart", TemperatureC = 13, Forecast = "Cold and windy" });
        }
    }
}