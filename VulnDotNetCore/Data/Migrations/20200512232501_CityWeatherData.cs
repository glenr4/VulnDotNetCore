using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VulnDotNetCore.Data.Migrations
{
    public partial class CityWeatherData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CityWeather",
                columns: new[] { "ID", "CityName", "Forecast", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("da5f6d56-2a89-4321-b4bc-dfd4ff90bd3b"), "Melbourne", "Grey and cold", 12.0m },
                    { new Guid("aab8cab1-d77e-4b42-bb68-48eb14c9d50e"), "Sydney", "Warm", 20.1m },
                    { new Guid("de884a80-9f47-460d-9f9f-84b3ed521cf1"), "Brisbane", "Sunny", 25m },
                    { new Guid("152c4eb4-0595-4b47-a2f0-c2f41ab2c555"), "Adelaide", "Warm", 18m },
                    { new Guid("7b31614b-af67-4382-ab28-0a56ef11f0ad"), "Perth", "Sunny and windy", 28m },
                    { new Guid("16bcd74e-734c-451d-9e36-1868a1cbdf25"), "Hobart", "Cold and windy", 13m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CityWeather",
                keyColumn: "ID",
                keyValue: new Guid("152c4eb4-0595-4b47-a2f0-c2f41ab2c555"));

            migrationBuilder.DeleteData(
                table: "CityWeather",
                keyColumn: "ID",
                keyValue: new Guid("16bcd74e-734c-451d-9e36-1868a1cbdf25"));

            migrationBuilder.DeleteData(
                table: "CityWeather",
                keyColumn: "ID",
                keyValue: new Guid("7b31614b-af67-4382-ab28-0a56ef11f0ad"));

            migrationBuilder.DeleteData(
                table: "CityWeather",
                keyColumn: "ID",
                keyValue: new Guid("aab8cab1-d77e-4b42-bb68-48eb14c9d50e"));

            migrationBuilder.DeleteData(
                table: "CityWeather",
                keyColumn: "ID",
                keyValue: new Guid("da5f6d56-2a89-4321-b4bc-dfd4ff90bd3b"));

            migrationBuilder.DeleteData(
                table: "CityWeather",
                keyColumn: "ID",
                keyValue: new Guid("de884a80-9f47-460d-9f9f-84b3ed521cf1"));
        }
    }
}
