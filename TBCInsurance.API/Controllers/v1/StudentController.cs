using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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
        //private IMediator _mediator;
       // protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetStudents")]
        public Task<IQueryable<StudentViewModel>> GetStudents()
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
        public  Task<bool> AddStudent(StudentViewModel student)
        {

            return  _studentService.AddStudent(student);
        }

        [HttpPut("UpdateStudent")]
        public  Task<bool> UpdateStudent(StudentViewModel student)
        {
            return _studentService.UpdateStudent(student);
        }

        [HttpDelete("RemoveStudent")]
        public Task<bool> RemoveStudent(int id)
        {

            return _studentService.RemoveStudent(id);
        }
    }
}
