using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace net_core_api_boiler_plate.Extensions.Services
{
    public static class LoggingService
    {
        public static void AddLoggingService(this IServiceCollection services, IConfiguration configuration)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var logDirectory = Path.Combine(currentDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            var logger = new LoggerConfiguration()
                            .WriteTo.Console(LogEventLevel.Information)
                            .ReadFrom.Configuration(configuration)
                            .CreateLogger();
            services.AddSingleton(logger);

            Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console(LogEventLevel.Information)
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();
            services.AddSingleton(Log.Logger);
        }
    }
}