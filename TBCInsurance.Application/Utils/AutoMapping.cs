using TBCInsurance.Domain.Models;
namespace TBCInsurance.Application.Utils
{
    using AutoMapper;
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<StudentViewModel, Student>(); // means you want to map from User to UserDTO
        }
    }
}
