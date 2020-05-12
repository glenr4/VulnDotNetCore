using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace VulnDotNetCore.Data.Migrations
{
    public partial class TestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Test", new[] { "ID", "Description" }, new object[] { Guid.NewGuid(), "Test description 1" });
            migrationBuilder.InsertData("Test", new[] { "ID", "Description" }, new object[] { Guid.NewGuid(), "Test description 2" });
            migrationBuilder.InsertData("Test", new[] { "ID", "Description" }, new object[] { Guid.NewGuid(), "Test description 3" });
            migrationBuilder.InsertData("Test", new[] { "ID", "Description" }, new object[] { Guid.NewGuid(), "Test description 4" });
            migrationBuilder.InsertData("Test", new[] { "ID", "Description" }, new object[] { Guid.NewGuid(), "Test description 5" });
            migrationBuilder.InsertData("Test", new[] { "ID", "Description" }, new object[] { Guid.NewGuid(), "Test description 6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Test;");
        }
    }
}