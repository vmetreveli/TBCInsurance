using System.Threading.Tasks;
using CleanArchitecture.Application.Features.StudentFeatures.Commands;
using CleanArchitecture.Application.Features.StudentFeatures.Dto;
using CleanArchitecture.Application.Features.StudentFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class StudentController : ApiController
    {

        private readonly IMediator _mediator;

        public StudentController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents() =>
            Ok(await _mediator.Send(new GetAllStudentsQuery()));

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(StudentDto student) =>
            Ok(await _mediator.Send(new CreateStudentCommand { Students = student }));

        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(StudentDto student) =>
            Ok(await _mediator.Send(new UpdateStudentCommand { Student = student }));

        [HttpDelete("RemoveStudent")]
        public async Task<IActionResult> RemoveStudent(int id) =>
            Ok(await _mediator.Send(new DeleteStudentCommand { Id = id }));
    }
}