using CleanArchitecture.Application.Students.Dto;
using CleanArchitecture.Domain.Models;
using MediatR;
namespace CleanArchitecture.Application.Students.Commands
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public StudentDto Student { get; set; }
    }
}