using AutoMapper;
using CleanArchitecture.Domain.Models;
using TBCInsurance.Application.ViewModels;
namespace TBCInsurance.Application.Utils
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<StudentViewModel, Student>(); // means you want to map from User to UserDTO
        }
    }
}
