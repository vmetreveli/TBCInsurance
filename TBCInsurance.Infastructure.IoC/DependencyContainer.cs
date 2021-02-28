using System;
using System.Linq;
using System.Reflection;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Application.Services;
using TBCInsurance.Application.Utils;
using MediatR;
using TBCInsurance.Application.Students.Dto;
using TBCInsurance.Application.Students.Handlers;
using TBCInsurance.Application.Students.MappingProfiles;
using TBCInsurance.Application.Students.Queries;
namespace TBCInsurance.Infastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //CleanArchitecture.Application
            services.AddScoped<IStudentService, StudentService>();

            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            services.AddScoped<IRepository<Student>, Repository<Student>>();

            //  services.AddAutoMapper(typeof(DependencyContainer));

            services.AddAutoMapper(c => c.AddProfile<StudentMappingProfile>(), typeof(DependencyContainer));

            services.AddMediatR(typeof(GetAllStudentsQuery));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            //services.AddMediatR(typeof(Startup));
          //  services.AddMediatR(typeof(TBCInsurance.Application).GetTypeInfo().Assembly);


        }
    }
}
