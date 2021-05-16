using System;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Identity.Models;
using CleanArchitecture.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace API
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            //  await CreateHostBuilder(args).Build().RunAsync();
            var host = CreateHostBuilder(args)
                .Build();


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