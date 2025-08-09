using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace ASP_MVC.Configurations
{
    public static class SerilogConfigurationExtensions
    {
        public static void ConfigureSerilog(this IHostApplicationBuilder builder)
        {
            var appSettings = new AppSettings();
            builder.Configuration.GetSection("AppSettings").Bind(appSettings);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .MinimumLevel.Is(ParseLevel(appSettings.Logging.MinimumLevel))
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    path: appSettings.Logging.FilePath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: appSettings.Logging.RetainedFileCountLimit,
                    restrictedToMinimumLevel: ParseLevel(appSettings.Logging.MinimumLevel))
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(Log.Logger, dispose: true);
        }

        private static LogEventLevel ParseLevel(string level)
        {
            return level?.ToLowerInvariant() switch
            {
                "verbose" => LogEventLevel.Verbose,
                "debug" => LogEventLevel.Debug,
                "information" => LogEventLevel.Information,
                "warning" => LogEventLevel.Warning,
                "error" => LogEventLevel.Error,
                "fatal" => LogEventLevel.Fatal,
                _ => LogEventLevel.Information
            };
        }
    }
}



