using System.Reflection;
using CleanArchitecture.Application.Features.StudentFeatures.MappingProfiles;
using CleanArchitecture.Application.Features.StudentFeatures.Queries;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infra.Data.Repositories;
using CleanArchitecture.Infrastructure.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace CleanArchitecture.Infrastructure.IoC

{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();


            //CleanArchitecture.Application
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<DbContext, UniDbContext>();

            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            services.AddScoped<IRepository<Student>, Repository<Student>>();

            services.AddAutoMapper(c => c.AddProfile<StudentMappingProfile>(),
                typeof(DependencyContainer));

            services.AddMediatR(typeof(GetAllStudentsQuery));
            services.AddMediatR(Assembly.GetExecutingAssembly());



        }
    }
}