using System;
using System.Security.Claims;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Identity.Models;
using CleanArchitecture.Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MVC.Controllers
{
    public class AccountController : Controller
    {
       // private readonly IUserService _userService;

        // public AccountController(IUserService userService) =>
        //     _userService = userService;

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
           // if (ModelState.IsValid)
            // {
            //     var result = _userService.GetTokenAsync(new TokenRequestModel
            //     {
            //         Password = model.Password,
            //         Email = model.Email
            //     });
            //
            //     if (result.Result == null)
            //     {
            //         ModelState.AddModelError("message", "Invalid login attempt");
            //         return View(model);
            //     }
            //
            //     if (result.Result.IsAuthenticated)
            //     {
            //         var claims = new[]
            //         {
            //             new Claim(ClaimTypes.Name, model.Email),
            //             new Claim("AcessToken", $"Bearer {result.Result.Token}")
            //         };
            //
            //
            //
            //         return Redirect("/Company/Dashboard");
            //     }
            // }

            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() =>
            throw new NotImplementedException();


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel request) =>
            throw new NotImplementedException();


        public async Task<IActionResult> Logout()
        {
            // await _userService.SignOutAsync();
            return RedirectToAction("login", "account");
        }

        public IActionResult AccessDenied() =>
            View();
    }
}