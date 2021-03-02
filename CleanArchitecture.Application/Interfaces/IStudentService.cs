using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Students.Dto;
using CleanArchitecture.Domain.Models;
namespace CleanArchitecture.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IQueryable<StudentDto>> GetStudents();
        Task<StudentDto> GetStudentById(int id);
        Task<PagedResult<StudentDto>> FindStudents(string filter);
        Task<bool> AddStudent(StudentDto student);
        Task<bool> RemoveStudent(int id);
        Task<bool> UpdateStudent(StudentDto student);
    }
}