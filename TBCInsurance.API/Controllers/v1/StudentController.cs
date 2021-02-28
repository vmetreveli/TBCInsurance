using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Application.Students.Dto;
using TBCInsurance.Application.Students.Queries;
namespace API.Controllers.v1
{

    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;
        private IMediator _mediator;
        private IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
            //_mediator = mediator;
        }

        [HttpGet("GetStudents")]
        public async Task<IQueryable<StudentDto>> GetStudents()
        {
            //_mediator.Send();
         //   return _studentService.GetStudents();
        return await Mediator.Send(new GetAllStudentsQuery());

        }


        // [HttpPost]
        // public PagedResult<StudentViewModel> FindStudents([FromForm] string filter)
        // {
        //
        //     return _studentService.FindStudents(filter);
        // }
        [HttpPost("AddStudent")]
        public  Task<bool> AddStudent(StudentDto student)
        {

            return  _studentService.AddStudent(student);
        }

        [HttpPut("UpdateStudent")]
        public  Task<bool> UpdateStudent(StudentDto student)
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
