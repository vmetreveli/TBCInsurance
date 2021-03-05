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

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetStudents")]
        public async Task<IEnumerable<StudentDto>> GetStudents() =>
            await _mediator.Send(new GetAllStudentsQuery());

        [HttpPost("AddStudent")]
        public Task<bool> AddStudent(StudentDto student) =>
            _mediator.Send(new CreateStudentCommand { Students = student });

        [HttpPut("UpdateStudent")]
        public Task<bool> UpdateStudent(StudentDto student) =>
            _mediator.Send(new UpdateStudentCommand { Student = student});

        [HttpDelete("RemoveStudent")]
        public Task<bool> RemoveStudent(int id) =>
          _mediator.Send(new DeleteStudentCommand { Id = id });
    }
}