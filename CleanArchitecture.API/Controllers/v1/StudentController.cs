using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Commands;
using CleanArchitecture.Application.Students.Dto;
using CleanArchitecture.Application.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers.v1
{

    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        private readonly IMediator _mediator;
        // private IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public StudentController(IStudentService studentService, IMediator mediator)
        {
            _studentService = studentService;
            _mediator = mediator;
        }

        [HttpGet("GetStudents")]
        public async Task<IEnumerable<StudentDto>> GetStudents() =>
            //_mediator.Send();
            //   return _studentService.GetStudents();
            await _mediator.Send(new GetAllStudentsQuery());
        /*var student = await _mediator.Send(new GetAllStudentsQuery());
      if (student == null) {
          return NotFound();
      }
      return Ok(student);*/

        // [HttpPost]
        // public PagedResult<StudentViewModel> FindStudents([FromForm] string filter)
        // {
        //
        //     return _studentService.FindStudents(filter);
        // }
        [HttpPost("AddStudent")]
        public Task<bool> AddStudent(StudentDto student) =>
            _mediator.Send(new CreateStudentCommand { Students = student });
        //   return  _studentService.AddStudent(student);
        [HttpPut("UpdateStudent")]
        public Task<bool> UpdateStudent(StudentDto student) =>
            _studentService.UpdateStudent(student);

        [HttpDelete("RemoveStudent")]
        public Task<bool> RemoveStudent(int id) =>
            _studentService.RemoveStudent(id);
    }
}