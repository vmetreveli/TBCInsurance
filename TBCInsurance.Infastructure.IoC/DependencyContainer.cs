using TBCInsurance.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Application.Services;
using TBCInsurance.Infastructure.Data.Repositories;

namespace TBCInsurance.Infastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //CleanArchitecture.Application
            services.AddScoped<IStudentService, StudentService>();

            //CleanArchitecture.Domain.Interfaces | CleanArchitecture.Infra.Data.Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();
        }  
    }
}
