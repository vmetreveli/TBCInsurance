using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Application.ViewModels;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
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


        // [HttpPost]
        // public PagedResult<StudentViewModel> FindStudents([FromForm] string filter)
        // {
        //
        //     return _studentService.FindStudents(filter);
        // } 
        [HttpPost("AddStudent")]
        public bool AddStudent(StudentViewModel student)
        {

            return _studentService.AddStudent(student);
        }

        [HttpPut("UpdateStudent")]
        public bool UpdateStudent(StudentViewModel student)
        {

            return _studentService.UpdateStudent(student);
        }

        [HttpDelete("RemoveStudent")]
        public bool RemoveStudent(int id)
        {

            return _studentService.RemoveStudent(id);
        }
    }
}
