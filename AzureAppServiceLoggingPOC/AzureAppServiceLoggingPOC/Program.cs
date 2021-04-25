using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AzureAppServiceLoggingPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            LoggingApplication app = serviceProvider.GetService<LoggingApplication>();

            // Initiale All Levels
            app.LogTrace();
            app.LogDebug();
            app.LogInformation();
            app.LogWarning();
            app.LogError();
            app.LogCritical();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
            .AddTransient<LoggingApplication>();
        }
    }
}
