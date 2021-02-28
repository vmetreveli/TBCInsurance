using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Models;
using TBCInsurance.Application.ViewModels;
namespace TBCInsurance.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IQueryable<StudentViewModel>> GetStudents();
        Task<PagedResult<StudentViewModel>>FindStudents(string filter);
        Task<bool> AddStudent(StudentViewModel student);
        Task<bool> RemoveStudent(int id);
        Task<bool> UpdateStudent(StudentViewModel student);
    }
}
