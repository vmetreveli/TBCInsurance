using CleanArchitecture.Application.Students.Dto;
using MediatR;
namespace CleanArchitecture.Application.Students.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public StudentDto Student { get; init; }
    }
}