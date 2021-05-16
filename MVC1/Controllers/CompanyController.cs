using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MVC1.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {

        private readonly ICompanyService _company;

        public CompanyController(ICompanyService company) =>
            _company = company;

        // GET: Products
        public async Task<IActionResult> Index() =>
            View(await _company.GetCompanies());

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var company = await _company.GetCompanyById((int)id);
            if (company == null) return NotFound();

            return View(company);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _company.GetCompanyById((int)id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(int id, Company model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid) _company.ChangeCompanyPriceOnMarket(model);
            return View(model);
        }
        public IActionResult Logout() =>
            SignOut("Cookies", "oidc");
    }
}