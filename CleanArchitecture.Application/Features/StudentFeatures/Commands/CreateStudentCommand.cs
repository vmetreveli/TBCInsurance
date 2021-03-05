using CleanArchitecture.Application.Students.Dto;
using MediatR;
namespace CleanArchitecture.Application.Students.Commands
{
    public class CreateStudentCommand : IRequest<int>
    {
        public StudentDto Students { get; init; }
    }
}