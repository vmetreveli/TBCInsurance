using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Models;
namespace CleanArchitecture.Application.Services
{
    public class CompanyService:ICompanyService
    {
    public Task<PagedResult<Company>> GetCompanies() =>
            throw new System.NotImplementedException();
    }
}