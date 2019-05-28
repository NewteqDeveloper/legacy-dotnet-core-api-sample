using ExtendedSample.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace ExtendedSample
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
