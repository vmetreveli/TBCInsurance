using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Application.Students.Dto;
namespace CleanArchitecture.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IQueryable<StudentDto>> GetStudents();
        Task<StudentDto> GetStudentById(int id);
        Task<PagedResult<StudentDto>>FindStudents(string filter);
        Task<bool> AddStudent(StudentDto student);
        Task<bool> RemoveStudent(int id);
        Task<bool> UpdateStudent(StudentDto student);
    }
}
