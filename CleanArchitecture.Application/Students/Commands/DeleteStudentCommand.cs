using CleanArchitecture.Domain.Models;
using MediatR;
namespace CleanArchitecture.Application.Students.Commands
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}