using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Commands;
using MediatR;
namespace CleanArchitecture.Application.Students.Handlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentService _service;

        public DeleteStudentCommandHandler(IStudentService service)
        {
            _service = service;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _service.RemoveStudent(request.Id);
        }
    }
}
