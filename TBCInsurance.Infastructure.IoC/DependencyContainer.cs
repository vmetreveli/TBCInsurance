using System;
using System.Reflection;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Application.Services;
using TBCInsurance.Application.Utils;
using MediatR;
using TBCInsurance.Application.Students.MappingProfiles;
namespace TBCInsurance.Infastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //CleanArchitecture.Application
            services.AddScoped<IStudentService, StudentService>();

            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            services.AddScoped<IRepository<Student>, Repository<Student>>();

            //  services.AddAutoMapper(typeof(DependencyContainer));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());//c => c.AddProfile<StudentMappingProfile>(), typeof(DependencyContainer));


            services.AddMediatR(Assembly.GetExecutingAssembly());


        }
    }
}
