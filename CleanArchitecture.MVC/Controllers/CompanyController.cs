using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Models;
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
            var pageFilter = new PageFilter
            {
                PageIndex = 0,
                PageSize = 15
            };

            var res = _company.GetCompanies(pageFilter);
            return View(res);
        }
    }
}