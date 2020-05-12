using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VulnDotNetCore.Data.Migrations
{
    public partial class CityWeather : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityWeather",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CityName = table.Column<string>(nullable: true),
                    TemperatureC = table.Column<decimal>(nullable: false),
                    Forecast = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityWeather", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityWeather");
        }
    }
}