using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Application.ViewModels;
namespace API.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
   // [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMediator _mediator;
        

        public StudentController(IStudentService studentService, IMediator mediator)
        {
            _studentService = studentService;
            _mediator = mediator;
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
        public  bool AddStudent(StudentViewModel student)
        {
          
            return _studentService.AddStudent(student);
        }

        [HttpPut("UpdateStudent")]
        public  bool UpdateStudent(StudentViewModel student)
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
