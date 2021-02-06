using Microsoft.AspNetCore.Mvc;
using TBCInsurance.Application;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Domain.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IStudentService _studentService;
        
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("index");
        }
        
        [HttpPost]
        public PagedResult<StudentViewModel> FindStudents([FromForm] PageFilter filter)
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
