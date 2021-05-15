using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Features.StudentFeatures.Dto;
using CleanArchitecture.Domain.Models;
namespace CleanArchitecture.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IQueryable<StudentDto>> GetStudents();
        Task<StudentDto> GetStudentById(int id);
        Task<PagedResult<StudentDto>> FindStudents(string filter);
        Task<int> AddStudent(StudentDto student);
        Task<int> RemoveStudent(int id);
        Task<int> UpdateStudent(StudentDto student);
    }
}