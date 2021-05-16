using System;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Identity.Models;
using CleanArchitecture.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace MVC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //  await CreateHostBuilder(args).Build().RunAsync();
            var host = CreateHostBuilder(args)
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    //Seed Default Users
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await UniDbContextSeed.SeedEssentialsAsync(userManager, roleManager);
                }
                catch(Exception ex)
                {

                }
            }

            await host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}