using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Models;
namespace CleanArchitecture.Application.Interfaces
{
    public interface ISalesService
    {

        Task<IEnumerable<Market>> GetCompanyByMarket(Market model);

    }
}