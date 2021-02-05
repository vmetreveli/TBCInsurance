using System.Collections.Generic;
using TBCInsurance.Domain.Interfaces;
using TBCInsurance.Domain.Models;
using TBCInsurance.Infastructure.Data.Context;

namespace TBCInsurance.Infastructure.Data.Repositories
{
    public class StudentRepository :IStudentRepository
    {
        public UniDbContext _context;
        public StudentRepository(UniDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetStudents()
        {
            // Add this line
            return _context.Students;
        }
    }
}
