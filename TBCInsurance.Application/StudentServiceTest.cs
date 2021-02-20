using System;
using System.Linq;
using CleanArchitecture.Domain.Models;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Application.ViewModels;
using Xunit;
namespace TBCInsurance.Application
{

    public class StudentServiceTest : IStudentService
    {

        [Fact]
        public IQueryable<StudentViewModel> GetStudents()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public PagedResult<StudentViewModel> FindStudents(string filter)
        {
            throw new NotImplementedException();
        }
        [Fact]
        public bool AddStudent(StudentViewModel student)
        {
            throw new NotImplementedException();
        }
        [Fact]
        public bool RemoveStudent(int id)
        {
            throw new NotImplementedException();
        }
        [Fact]
        public bool UpdateStudent(StudentViewModel student)
        {
            throw new NotImplementedException();
        }
    }
}
