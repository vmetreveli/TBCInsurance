using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Commands;
using CleanArchitecture.Application.Students.Dto;
using CleanArchitecture.Application.Students.Queries;
namespace API.Controllers.v1
{

    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;
        private IMediator _mediator;
       // private IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public StudentController(IStudentService studentService, IMediator mediator)
        {
            _studentService = studentService;
            _mediator = mediator;
        }

        [HttpGet("GetStudents")]
        public async Task<IEnumerable<StudentDto>> GetStudents()
        {
            //_mediator.Send();
         //   return _studentService.GetStudents();
return await _mediator.Send(new GetAllStudentsQuery());


      /*var student = await _mediator.Send(new GetAllStudentsQuery());
      if (student == null) {
          return NotFound();
      }
      return Ok(student);*/

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
          return  _mediator.Send(new CreateStudentCommand{Students = student});
            //   return  _studentService.AddStudent(student);
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
