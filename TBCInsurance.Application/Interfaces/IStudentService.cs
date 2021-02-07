using System.Linq;
using TBCInsurance.Domain.Models;
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
