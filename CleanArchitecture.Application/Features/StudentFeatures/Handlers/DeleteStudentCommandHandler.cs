using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Features.StudentFeatures.Commands;
using CleanArchitecture.Application.Interfaces;
using MediatR;
namespace CleanArchitecture.Application.Features.StudentFeatures.Handlers
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
