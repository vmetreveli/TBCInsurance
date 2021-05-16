using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CompanyController : ApiController
    {

        private readonly ICompanyService _company;

        public CompanyController(ICompanyService company) =>
            _company = company;

        // GET: GetCompanies
        public async Task<IActionResult> GetCompanies() =>
            Ok(await _company.GetCompanies());
    }
}