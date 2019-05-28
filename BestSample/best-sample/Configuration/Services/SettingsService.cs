using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestSample.Configuration.Services
{
    public class SettingsService
    {
        private readonly IConfigurationBuilder configurationBuilder;

        public SettingsService()
        {
            this.configurationBuilder = new ConfigurationBuilder();
        }

        public IConfigurationRoot BuildSettingsConfiguration(string contentPath, string environmentName)
        {
            configurationBuilder
                .SetBasePath(contentPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();

            return configurationBuilder.Build();
        }
    }
}
