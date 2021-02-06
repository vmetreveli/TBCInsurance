using TBCInsurance.Domain.Interfaces;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Domain.Models;

namespace TBCInsurance.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentViewModel GetStudents()
        {
            return new StudentViewModel() { Students = _studentRepository.GetAll() };
        }
    }
}
