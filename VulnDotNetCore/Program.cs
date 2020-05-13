using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace VulnDotNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.CaptureStartupErrors(true);
                    webBuilder.UseStartup<Startup>();
                })
                // Log.Logger is assigned implicitly and closed when the app is shut down
                // https://github.com/serilog/serilog-aspnetcore
                .UseSerilog((hostingContext, loggerConfiguration) =>
                    loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration)
                    .Enrich.FromLogContext()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .MinimumLevel.Override("System", LogEventLevel.Debug)
                    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                    .WriteTo.ApplicationInsights(TelemetryConfiguration.Active, TelemetryConverter.Traces)
                    .WriteTo.Console());
        }
    }
}