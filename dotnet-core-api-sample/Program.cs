using dotnet_core_api_sample.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace dotnet_core_api_sample
{
    public class Program
    {
        public static void Main()
        {
            var builder = new HostBuilder();
            builder.Build<Startup>().Run();
        }
    }
}
