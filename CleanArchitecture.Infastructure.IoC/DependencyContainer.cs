using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace CleanArchitecture.Infrastructure.IoC

{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {


            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<DbContext, UniDbContext>();
            services.AddScoped<IServiceCollection, ServiceCollection>();

        }
    }
}