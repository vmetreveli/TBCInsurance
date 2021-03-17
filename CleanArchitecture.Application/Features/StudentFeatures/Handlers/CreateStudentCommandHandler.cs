using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Features.StudentFeatures.Commands;
using CleanArchitecture.Application.Interfaces;
using MediatR;
namespace CleanArchitecture.Application.Features.StudentFeatures.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentService _service;

        public CreateStudentCommandHandler(IStudentService service)
        {
            _service = service;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            return await _service.AddStudent(request.Students);
        }
    }
}
