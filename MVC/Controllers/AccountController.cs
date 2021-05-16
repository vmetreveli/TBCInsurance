using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Identity.Models;
using CleanArchitecture.Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService) =>
            _userService = userService;

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.GetTokenAsync(new TokenRequestModel
                {
                    Password = model.Password,
                    Email = model.Email
                });

                if (result.Result == null)
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(model);
                }
                else if(result.Result.IsAuthenticated)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, model.Email),
                        new Claim("AcessToken", string.Format("Bearer {0}", result.Result.Token)),
                    };

                    var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                    var options = new AuthenticationProperties();

                    IOwinContext context = HttpContext.Current.GetOwinContext();
                    Request.GetOwinContext().Authentication.SignIn(options, identity);

                    return RedirectToAction("Dashboard");
                }
            }

            return View(model);
        }


        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            throw new NotImplementedException();
        }


        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel request)
        {
            throw new NotImplementedException();

        }

        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.SignOutAsync();
            return RedirectToAction("login", "account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
