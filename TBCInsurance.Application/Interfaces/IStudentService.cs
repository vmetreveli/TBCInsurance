using System.Linq;
using TBCInsurance.Domain.Models;
namespace TBCInsurance.Application.Interfaces
{
    public interface IStudentService
    {
        IQueryable<StudentViewModel> GetStudents(); 
        PagedResult<StudentViewModel> FindStudents(PageFilter filter);
        bool AddStudent(StudentViewModel student);
        bool RemoveStudent(int id);
    }
}
