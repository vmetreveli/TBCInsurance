using CleanArchitecture.Domain.Models;
using MediatR;
using CleanArchitecture.Application.Students.Dto;

namespace CleanArchitecture.Application.Students.Commands
{
    public class CreateStudentCommand: IRequest<bool>
    {
        public StudentDto Students { get; set; }
    }
}