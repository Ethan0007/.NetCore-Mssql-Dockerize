using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleApis.Data.Entities;
using System;
using System.Threading.Tasks;

namespace SampleApis
{
    public class Program
    {
        public static void MigrateDatabase(IHost host)
        {
            if (host is null)
            {
                throw new ArgumentNullException(nameof(host));
            }

            var serviceScopeFactory = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<SystemsDbContext>();
                dbContext.Database.Migrate();
            }
        }

        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            MigrateDatabase(host);
            await host.RunAsync().ConfigureAwait(false);
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
