using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TBCInsurance.Application;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Domain.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IStudentService _studentService;
        
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        [HttpGet("GetStudents")]
        public IQueryable<StudentViewModel> GetStudents()
        {
            return _studentService.GetStudents();
        }
        
        
        [HttpPost]
        public PagedResult<StudentViewModel> FindStudents([FromForm] string filter)
        {

            return _studentService.FindStudents(filter);
        } 
        [HttpPut]
        public bool AddStudent([FromForm] StudentViewModel student)
        {

            return _studentService.AddStudent(student);
        } 
        
        [HttpDelete]
        public bool RemoveStudent(int id)
        {

            return _studentService.RemoveStudent(id);
        }
    }
}
