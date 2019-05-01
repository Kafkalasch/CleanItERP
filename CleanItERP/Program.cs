using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CleanItERP.DataModel;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanItERP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            SeedData(host);

            host.Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void SeedData(IWebHost host){
            using(var scope = host.Services.CreateScope()){

                using(var context = scope.ServiceProvider.GetRequiredService<CleanItERPContext>())
                {
                        var seeder = new DatabaseSeeder(context);
                        seeder.SeedIfEmpty();
                }
            }
        }


        
    }
}
