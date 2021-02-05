using System.Collections.Generic;
using TBCInsurance.Domain.Models;

namespace TBCInsurance.Domain.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
    }
}
