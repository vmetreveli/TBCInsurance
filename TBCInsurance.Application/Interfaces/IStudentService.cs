using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Models;
using TBCInsurance.Application.Students.Dto;
namespace TBCInsurance.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IQueryable<StudentDto>> GetStudents();
        Task<PagedResult<StudentDto>>FindStudents(string filter);
        Task<bool> AddStudent(StudentDto student);
        Task<bool> RemoveStudent(int id);
        Task<bool> UpdateStudent(StudentDto student);
    }
}
