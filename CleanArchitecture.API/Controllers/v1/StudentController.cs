using System.Threading.Tasks;
using CleanArchitecture.Application.Features.StudentFeatures.Commands;
using CleanArchitecture.Application.Features.StudentFeatures.Dto;
using CleanArchitecture.Application.Features.StudentFeatures.Queries;
using CleanArchitecture.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class StudentController : ApiController
    {

        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _mediator.Send(new GetAllStudentsQuery()));
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(StudentDto student)
        {
            return Ok(await _mediator.Send(new CreateStudentCommand { Students = student }));
        }

        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(StudentDto student)
        {
            return Ok(await _mediator.Send(new UpdateStudentCommand { Student = student }));
        }

        [HttpDelete("RemoveStudent")]
        public async Task<IActionResult> RemoveStudent(int id)
        {
            return Ok(await _mediator.Send(new DeleteStudentCommand { Id = id }));
        }
    }
}
