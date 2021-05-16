using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MVC.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {

        private readonly ICompanyService _company;

        public CompanyController(ICompanyService company) =>
            _company = company;
        //[Authorize]

        public IActionResult Dashboard()
        {
            var res = _company.GetCompanies();
            return View(res);
        }
    }
}