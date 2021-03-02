using CleanArchitecture.Domain.Models;
using MediatR;
namespace CleanArchitecture.Application.Students.Commands
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public Student Student { get; set; }
    }
}