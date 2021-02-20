using System.Linq;
using CleanArchitecture.Domain.Models;
using TBCInsurance.Application.ViewModels;
namespace TBCInsurance.Application.Interfaces
{
    public interface IStudentService
    {
        IQueryable<StudentViewModel> GetStudents();
        PagedResult<StudentViewModel> FindStudents(string filter);
        bool AddStudent(StudentViewModel student);
        bool RemoveStudent(int id);
        bool UpdateStudent(StudentViewModel student);
    }
}
