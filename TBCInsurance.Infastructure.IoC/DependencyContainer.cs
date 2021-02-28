using System.Reflection;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Application.Services;
using TBCInsurance.Application.Utils;
using MediatR;
namespace TBCInsurance.Infastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //CleanArchitecture.Application
            services.AddScoped<IStudentService, StudentService>();

            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            services.AddScoped<IRepository<Student>, Repository<Student>>();

            //  services.AddAutoMapper(typeof(DependencyContainer));

            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(DependencyContainer));

            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
