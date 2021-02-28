using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CleanArchitecture.Domain.Models;
using TBCInsurance.Application.Students.Dto;
namespace TBCInsurance.Application.Students.MappingProfiles
{
    public class StudentMappingProfile: Profile
    {
        public StudentMappingProfile()
        {
          //  CreateMap<StudentDto, Student>(); // means you want to map from User to UserDTO
          CreateMap<Student, StudentDto>();
        //  CreateMap<IQueryable<Student>, IQueryable<StudentDto>>();
          CreateMap<IEnumerable<Student>, IEnumerable<StudentDto>>();
          // .ForMember(c => c.Name, option => option.Ignore())
          // .ForMember(c => c.BirthDate, option => option.Ignore());
        }
    }
}