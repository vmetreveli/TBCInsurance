using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Identity.Models;

namespace MVC.Controllers.Auth
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AuthenticationController : Controller
    {

        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService) =>
            _userService = userService;

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
         return Ok( _userService.GetTokenAsync(new TokenRequestModel
            {
                Password = model.Password,
                Email = model.Email
            }));

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel Input)
        {
            throw new NotImplementedException();

        }

    }
}