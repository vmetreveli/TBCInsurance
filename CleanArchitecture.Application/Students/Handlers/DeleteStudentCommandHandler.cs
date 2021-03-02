using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Commands;
using MediatR;
namespace CleanArchitecture.Application.Students.Handlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentService _service;

        public DeleteStudentCommandHandler(IStudentService service) =>
            _service = service;

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.RemoveStudent(request.Student.Id);
            return result;
        }
    }
}