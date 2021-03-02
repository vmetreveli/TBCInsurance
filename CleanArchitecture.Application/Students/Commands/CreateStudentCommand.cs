using CleanArchitecture.Application.Students.Dto;
using MediatR;
namespace CleanArchitecture.Application.Students.Commands
{
    public class CreateStudentCommand : IRequest<bool>
    {
        public StudentDto Students { get; set; }
    }
}