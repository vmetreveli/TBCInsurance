using AutoMapper;
using CleanArchitecture.Application.Students.Dto;
using CleanArchitecture.Domain.Models;
namespace CleanArchitecture.Application.Students.MappingProfiles
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            //  CreateMap<StudentDto, Student>(); // means you want to map from User to UserDTO
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

            // .ForMember(c => c.Name, option => option.Ignore())
            // .ForMember(c => c.BirthDate, option => option.Ignore());
        }
    }
}
