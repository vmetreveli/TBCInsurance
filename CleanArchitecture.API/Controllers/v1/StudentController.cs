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
        public async Task<IActionResult> GetStudents() =>
            Ok(_mediator.Send(new GetAllStudentsQuery()));

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(StudentDto student) =>
            Ok(_mediator.Send(new CreateStudentCommand { Students = student }));

        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(StudentDto student) =>
            Ok(_mediator.Send(new UpdateStudentCommand { Student = student}));

        [HttpDelete("RemoveStudent")]
        public  async Task<IActionResult> RemoveStudent(int id) =>
            Ok(_mediator.Send(new DeleteStudentCommand { Id = id }));
    }
}