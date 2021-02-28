using AutoMapper;
using CleanArchitecture.Domain.Models;
using TBCInsurance.Application.Students.Dto;
namespace TBCInsurance.Application.Students.MappingProfiles
{
    public class StudentMappingProfile: Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<StudentDto, Student>(); // means you want to map from User to UserDTO
        }
    }
}