using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace dotnet_core_api_sample.Hosting
{
    public class HostBuilder
    {
        public HostBuilder()
        {
            
        }

        public IWebHost Build<TStartup>()
        {
            var hostBuilder = new WebHostBuilder();
            var environment = hostBuilder.GetSetting("environment");
            var contentRoot = Directory.GetCurrentDirectory();

            IConfigurationRoot hostingConfig;
            var hostingBuilder = new ConfigurationBuilder();
            hostingConfig = hostingBuilder
                .SetBasePath(contentRoot)
                .AddJsonFile("hosting.json", false)
                .AddJsonFile($"hosting.{environment}.json", true)
                .Build();

            var host = hostBuilder
                .UseKestrel()
                .UseContentRoot(contentRoot)
                .UseConfiguration(hostingConfig)
                // .UseConfiguration(CreateConfig(contentRoot, environment))
                .ConfigureAppConfiguration((config) =>
                {
                    CreateConfig(config, contentRoot, environment);
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .UseStartup(typeof(TStartup))
                .Build();

            return host;
        }

        private void CreateConfig(IConfigurationBuilder configurationBuilder, string contentRoot, string environmentName)
        {
            var builder = configurationBuilder
                .SetBasePath(contentRoot)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true);

             // return builder.Build();
        }
    }
}
