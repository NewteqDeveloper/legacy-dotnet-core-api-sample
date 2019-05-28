using BestSample.Configuration.Services;
using Domain.Configuration.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BestSample
{
    public class Startup
    {
        private readonly ISettings settings;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            var settingsService = new SettingsService();
            var configuration = settingsService.BuildSettingsConfiguration(hostingEnvironment.ContentRootPath, hostingEnvironment.EnvironmentName);
            this.settings = new Settings(configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton(this.settings);
        }
    }
}
