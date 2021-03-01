using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Commands;
namespace CleanArchitecture.Application.Students.Handlers
{
    public class DeleteStudentCommandHandler: IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentService _service;

        public DeleteStudentCommandHandler(IStudentService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.RemoveStudent(request.Student.Id);
            return result;
        }
    }
}