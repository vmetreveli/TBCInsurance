using CleanArchitecture.Domain.Models;
using MediatR;
namespace TBCInsurance.Application.Students.Commands
{
    public class DeleteStudentCommand: IRequest<int>
    {
        public Student Student { get; set; }
    }
}