using TBCInsurance.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Application.Services;
using TBCInsurance.Application.Utils;
using TBCInsurance.Domain.Models;
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
            services.AddScoped<IRepository<Student>, Repository<Student>>();
            
          //  services.AddAutoMapper(typeof(DependencyContainer));
            
            services.AddAutoMapper(c=>c.AddProfile<AutoMapping>(), typeof(DependencyContainer));
        }  
    }
}
