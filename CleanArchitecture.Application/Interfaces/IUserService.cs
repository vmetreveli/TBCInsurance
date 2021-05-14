using System.Threading.Tasks;
using CleanArchitecture.Domain.Models.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterModel model);
    }
}