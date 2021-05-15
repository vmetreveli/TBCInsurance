using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Models;
namespace CleanArchitecture.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<PagedResult<Company>> GetCompanies();
        Task<int> CompanyRegister(Company model);
         Task<Company> GetCompanyById(int id);

    }
}