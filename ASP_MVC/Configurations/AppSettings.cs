using System;

namespace ASP_MVC.Configurations
{
    // Strongly-typed settings bound from configuration (appsettings.json)
    public sealed class AppSettings
    {
        public string ApplicationName { get; init; } = "ASP_MVC";
        public LoggingSettings Logging { get; init; } = new();
        public SecuritySettings Security { get; init; } = new();
    }

    public sealed class LoggingSettings
    {
        public string MinimumLevel { get; init; } = "Information";
        public string FilePath { get; init; } = "Logs/log-.txt";
        public int RetainedFileCountLimit { get; init; } = 7;
    }

    public sealed class SecuritySettings
    {
        public bool EnforceHttps { get; init; } = true;
        public int CookieExpireMinutes { get; init; } = 60;
    }
}



