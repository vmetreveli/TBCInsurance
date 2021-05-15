using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Models;
namespace CleanArchitecture.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompanies(PageFilter filter);
        Task<int> CompanyRegister(Company model);
        Task<Company> GetCompanyById(int id);
        Task<int> AddCompanyInMarket(Company model);

        Task<int> ChangeCompanyPriceOnMarket(Company model);
    }
}