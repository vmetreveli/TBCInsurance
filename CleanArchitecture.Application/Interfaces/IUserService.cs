﻿using System.Threading.Tasks;
using CleanArchitecture.Domain.Identity.Models;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Models.Entities;
namespace CleanArchitecture.Application.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterModel model);
        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
    }
}