using TBCInsurance.Domain.Interfaces;
using TBCInsurance.Application.Interfaces;

namespace TBCInsurance.Application.Services
{
    public class StudentService : IStudentService
    {
        public IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentViewModel GetStudents()
        {
            return new StudentViewModel() { Students = _studentRepository.GetStudents() };
        }
    }
}
