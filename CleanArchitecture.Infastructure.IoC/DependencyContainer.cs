using System.Reflection;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.Students.MappingProfiles;
using CleanArchitecture.Application.Students.Queries;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace CleanArchitecture.Infastructure.IoC

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

            //services.AddMediatR(typeof(Startup));
          //  services.AddMediatR(typeof(CleanArchitecture.Application).GetTypeInfo().Assembly);


        }
    }
}
